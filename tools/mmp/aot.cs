/*
 * Copyright 2016 Microsoft Inc
 *
 * Authors:
 *   Chris Hamons <chris.hamons@xamarin.com> 
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Xamarin.Bundler {
	enum AotType {
		Default,
		None,
		All,
		SDK,
		Explicit
	}

	public interface IFileEnumerator
	{
		IEnumerable<string> Files { get; }
		string RootDir { get; }
	}

	public class FileSystemEnumerator : IFileEnumerator
	{
		DirectoryInfo Info;
		public string RootDir { get; private set; }		

		public FileSystemEnumerator (string path)
		{
			RootDir = path;
			Info = new DirectoryInfo (path);
		}

		public IEnumerable<string> Files {
			get {
				return Info.GetFiles ().Select (x => x.Name);
			}
		}
	}

	public delegate int RunCommandDelegate (string path, string args, string[] env = null, StringBuilder output = null, bool suppressPrintOnErrors = false);

	public class AOTCompiler {
		AotType aot_type = AotType.Default;
		public bool IsAOT => aot_type != AotType.Default && aot_type != AotType.None; 
		
//		static List<string> aot_explicit_reference = new List<string> ();
//		static List<string> aot_ignore = new List<string> ();


		public string Quote (string f) => Driver.Quote (f);

		// Allows tests to stub out actual compilation and parallelism
		public RunCommandDelegate RunCommand { get; set; } = Driver.RunCommand; 
		public ParallelOptions ParallelOptions { get; set; } = new ParallelOptions () { MaxDegreeOfParallelism = Driver.Concurrency };

		public AOTCompiler ()
		{
		}

		public void Parse (string options)
		{
			switch (options) {
			case "none":
				aot_type = AotType.None;
				break;
			case "all":
				aot_type = AotType.All;
				break;
			case "sdk":
				aot_type = AotType.SDK;
				break;
			default:
				throw new MonoMacException (20, true, "The valid options for '{0}' are '{1}'.", "--aot", "none, all, sdk, and an explicit list of assemblies.");

			}
/*			var bits = options.Split (',');
			switch (bits[0]) {
				case "none":
					aot = AotType.None;
					break;
				case "all":
					aot = AotType.All;
					break;
				case "sdk":
					aot = AotType.SDK;
					break;
			}

				foreach (var assembly in assemblies) {
					if (assembly.StartsWith ("+", StringComparison.Ordinal)) {
						dlsym = true;
						asm = assembly.Substring (1);
					} else if (assembly.StartsWith ("-", StringComparison.Ordinal)) {
					}	
				}
			switch (options) {
			case "none":
				aot = AotType.None;
				break;
			case "all":
				aot = AotType.All;
				break;
			case "sdk":
				aot = AotType.SDK;
				break;
			default:
				var assemblies = options.Split (',');
				foreach (var assembly in assemblies) {
					if (assembly.StartsWith ("+", StringComparison.Ordinal)) {
						dlsym = true;
						asm = assembly.Substring (1);
					} else if (assembly.StartsWith ("-", StringComparison.Ordinal)) {
					}	
				}
				throw new MonoMacException (20, true, "The valid options for '{0}' are '{1}'.", "--aot", "none, all, sdk, and an explicit");
			}
*/
		}

		IEnumerable<string> GetFilesToAOT (IFileEnumerator files)
		{
			foreach (var file in files.Files) {
				string extension = Path.GetExtension (file);
				if (extension != ".exe" && extension != ".dll")
					continue;

				if (aot_type == AotType.SDK) {
					if (file != "Xamarin.Mac.dll" && file != "System.dll" && file != "mscorlib.dll")
						continue;
				}
				yield return file;
			}
		}
		
		public void Compile (string path)
		{
			Compile (new FileSystemEnumerator (path));
		}

		public void Compile (IFileEnumerator files)
		{
			if (!IsAOT)
				throw ErrorHelper.CreateError (0099, "Internal error \"AOTBundle with aot: {0}\" Please file a bug report with a test case (http://bugzilla.xamarin.com).", aot_type);

			string monoExe = "/Library/Frameworks/Xamarin.Mac.framework/Commands/bmac-mobile-mono";

/*
			Func <FileInfo, bool> aotableFile = x => {
				if (aot_ignore.Contains (x.Name))
					return false; 

				switch (aot) {
				case AotType.All:
					return true;
				case AotType.SDK:
					return x.Name == "Xamarin.Mac.dll" || x.Name == "System.dll" || x.Name == "mscorlib.dll";
				case AotType.Explicit:
					return aot_explicit_reference.Contains (x.Name);
				default:
					throw ErrorHelper.CreateError (0099, "Internal error \"AOTBundle with aot: {0}\" Please file a bug report with a test case (http://bugzilla.xamarin.com).", aot);
				}
			};
*/
			Parallel.ForEach (GetFilesToAOT (files), ParallelOptions, file => {
				int ret = RunCommand (monoExe, String.Format ("--aot=hybrid {0}", Quote (file.ToString ())), new string [] {"MONO_PATH", files.RootDir });
				if (ret != 0)
					ErrorHelper.Warning (5105, "Failed to AOT compile. Error code - {0}. Please file a bug report at http://bugzilla.xamarin.com", ret);
			});
		}
	}	
}
