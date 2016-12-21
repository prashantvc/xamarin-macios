using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Xamarin.Bundler;

namespace Xamarin.MMP.Tests.Unit
{
	[TestFixture]
	public class AotTests
	{
		const string TestRootDir = "/a/non/sense/dir";

		class TestFileEnumerator : IFileEnumerator
		{
			public IEnumerable<string> Files { get; }
			public string RootDir { get; } = TestRootDir;

			public TestFileEnumerator (IEnumerable <string> files)
			{
				Files = files;
			}
		}

		AOTCompiler compiler;
		List<Tuple<string, string>> commandsRun;

		[SetUp]
		public void Init ()
		{
			compiler = new AOTCompiler ()
			{
				RunCommand = OnRunCommand,
				ParallelOptions = new ParallelOptions () { MaxDegreeOfParallelism = 1 }
			};

			commandsRun = new List<Tuple<string, string>> ();
		}

		int OnRunCommand (string path, string args, string [] env, StringBuilder output, bool suppressPrintOnErrors)
		{
			Assert.IsTrue (env[0] == "MONO_PATH", "MONO_PATH should be first env set");
			Assert.IsTrue (env[1] == TestRootDir, "MONO_PATH should be set to our expected value");
			commandsRun.Add (Tuple.Create <string, string>(path, args));
			return 0;
		}

		List<String> GetFiledAOTed ()
		{
			List<string> filesAOTed = new List<string> (); 

			foreach (var command in commandsRun) {
				Assert.AreEqual (command.Item1, "/Library/Frameworks/Xamarin.Mac.framework/Commands/bmac-mobile-mono", "Command should be bmac-mobile-mono");
				Assert.AreEqual (command.Item2.Split (' ')[0], "--aot=hybrid", "First arg should be --aot=hybrid");
				string fileName = command.Item2.Substring (command.Item2.IndexOf(' ') + 1).Replace ("\"", "");
				filesAOTed.Add (fileName);
			}
			return filesAOTed;
		}

		readonly List<string> FullAppFileList = new List<string> () { 
			"Foo Bar.exe", "libMonoPosixHelper.dylib", "mscorlib.dll", "Xamarin.Mac.dll", "System.dll" 
		};

		readonly List<string> SDKFileList = new List<string> () { 
			"mscorlib.dll", "Xamarin.Mac.dll", "System.dll" 
		};

		[Test]
		public void ParsingSimpleOptions_None ()
		{
			compiler.Parse ("none");
			Assert.IsFalse (compiler.IsAOT, "Parsing none should not be IsAOT");
			try {
				compiler.Compile (new TestFileEnumerator (FullAppFileList));
			}
			catch (MonoMacException) {
				return;
			}
			Assert.Fail ("We should have thrown MonoMacException during compile on non-AOT");
		}

		[Test]
		public void ParsingSimpleOptions_All ()
		{
			compiler.Parse ("all");
			Assert.IsTrue (compiler.IsAOT, "Parsing all should be IsAOT");
		
			compiler.Compile (new TestFileEnumerator (FullAppFileList));
		
			List<string> filesAOTed = GetFiledAOTed ();

			Assert.AreEqual (filesAOTed.Count, 4, "All assemblies should be AOTed");
			Assert.IsTrue (filesAOTed.All (x => FullAppFileList.Contains (x)), "All assemblies should be in the FullAppFileList file list");
		}

		[Test]
		public void ParsingSimpleOptions_SDK ()
		{
			compiler.Parse ("sdk");
			Assert.IsTrue (compiler.IsAOT, "Parsing sdk should be IsAOT");
			
			compiler.Compile (new TestFileEnumerator (FullAppFileList));

			List<string> filesAOTed = GetFiledAOTed ();
			Assert.AreEqual (filesAOTed.Count, SDKFileList.Count, "Only SDK assemblies should be AOTed");
			Assert.IsTrue (filesAOTed.All (x => SDKFileList.Contains (x)), "All assemblies should be in the SDKFileList file list");
		}
	
		[ExpectedException (typeof (MonoMacException))]
		[Test]
		public void ParsingSimpleOptions_InvalidOption ()
		{
			compiler.Parse ("FooBar");
		}
	}
}
