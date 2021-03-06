//
// MACaptionAppearance Unit Tests
//
// Authors:
//	Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2013 Xamarin Inc.
//

#if !__WATCHOS__

using System;
#if XAMCORE_2_0
using Foundation;
using UIKit;
using MediaAccessibility;
#else
using MonoTouch.Foundation;
using MonoTouch.MediaAccessibility;
using MonoTouch.UIKit;
#endif
using NUnit.Framework;

namespace MonoTouchFixtures.MediaAccessibility {

	[TestFixture]
	// we want the test to be availble if we use the linker
	[Preserve (AllMembers = true)]
	public class CaptionAppearanceTest {

#if !XAMCORE_3_0
		[Test]
		public void Fields ()
		{
			if (TestRuntime.CheckSystemAndSDKVersion (7,0)) {
				Assert.NotNull (MACaptionAppearance.MediaCharacteristicDescribesMusicAndSoundForAccessibility, "MediaCharacteristicDescribesMusicAndSoundForAccessibility");
				Assert.NotNull (MACaptionAppearance.MediaCharacteristicTranscribesSpokenDialogForAccessibility, "MediaCharacteristicTranscribesSpokenDialogForAccessibility");
				Assert.NotNull (MACaptionAppearance.SettingsChangedNotification, "SettingsChangedNotification");
			} else {
				Assert.Null (MACaptionAppearance.MediaCharacteristicDescribesMusicAndSoundForAccessibility, "MediaCharacteristicDescribesMusicAndSoundForAccessibility");
				Assert.Null (MACaptionAppearance.MediaCharacteristicTranscribesSpokenDialogForAccessibility, "MediaCharacteristicTranscribesSpokenDialogForAccessibility");
				Assert.Null (MACaptionAppearance.SettingsChangedNotification, "SettingsChangedNotification");
			}
		}
#endif // !XAMCORE_3_0

		[Test]
		[Culture ("en")] // this setting depends on locale of the device according to apple docs on MACaptionAppearanceGetDisplayType, we know english works
		public void GetDisplayType ()
		{
			if (!TestRuntime.CheckSystemAndSDKVersion (7,0))
				Assert.Ignore ("requires iOS7+");

			Assert.That (MACaptionAppearance.GetDisplayType (MACaptionAppearanceDomain.Default), Is.EqualTo (MACaptionAppearanceDisplayType.Automatic), "Default");
		}
	}
}

#endif // !__WATCHOS__
