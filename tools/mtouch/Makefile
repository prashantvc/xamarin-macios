TOP=../..
include $(TOP)/Make.config

# without this many compiler warnings about unused functions and variables
# in system headers show up.
export CCACHE_CPP2=1

LINKER_DIR=../linker

CECIL_DIR=$(CECIL_PATH)
MONO_DIR=$(MONO_PATH)
MCS_TOOLS_DIR=$(MONO_DIR)/mcs/tools
MONOLINKER=$(MCS_TOOLS_DIR)/linker
MONO_TUNER=$(MCS_TOOLS_DIR)/tuner

LINKER_RESOURCES = \
	$(LINKER_DIR)/Descriptors/mscorlib.xml

LINKER_SOURCES = \
	$(MONOLINKER)/Mono.Linker/Annotations.cs			\
	$(MONOLINKER)/Mono.Linker/AssemblyAction.cs			\
	$(MONOLINKER)/Mono.Linker/AssemblyResolver.cs			\
	$(MONOLINKER)/Mono.Linker/I18nAssemblies.cs			\
	$(MONOLINKER)/Mono.Linker/IXApiVisitor.cs			\
	$(MONOLINKER)/Mono.Linker/LinkContext.cs			\
	$(MONOLINKER)/Mono.Linker/MethodAction.cs			\
	$(MONOLINKER)/Mono.Linker/Pipeline.cs				\
	$(MONOLINKER)/Mono.Linker/TypePreserve.cs			\
	$(MONOLINKER)/Mono.Linker/XApiReader.cs				\
	$(MONOLINKER)/Mono.Linker.Steps/BaseStep.cs			\
	$(MONOLINKER)/Mono.Linker.Steps/BlacklistStep.cs		\
	$(MONOLINKER)/Mono.Linker.Steps/CleanStep.cs			\
	$(MONOLINKER)/Mono.Linker.Steps/IStep.cs			\
	$(MONOLINKER)/Mono.Linker.Steps/LoadI18nAssemblies.cs		\
	$(MONOLINKER)/Mono.Linker.Steps/LoadReferencesStep.cs		\
	$(MONOLINKER)/Mono.Linker.Steps/MarkStep.cs			\
	$(MONOLINKER)/Mono.Linker.Steps/OutputStep.cs			\
	$(MONOLINKER)/Mono.Linker.Steps/ResolveFromAssemblyStep.cs	\
	$(MONOLINKER)/Mono.Linker.Steps/ResolveFromXApiStep.cs		\
	$(MONOLINKER)/Mono.Linker.Steps/ResolveFromXmlStep.cs		\
	$(MONOLINKER)/Mono.Linker.Steps/ResolveStep.cs			\
	$(MONOLINKER)/Mono.Linker.Steps/SweepStep.cs			\
	$(MONOLINKER)/Mono.Linker.Steps/TypeMapStep.cs			\
	$(MONO_TUNER)/Mono.Tuner/ApplyPreserveAttributeBase.cs		\
	$(MONO_TUNER)/Mono.Tuner/CecilRocks.cs				\
	$(MONO_TUNER)/Mono.Tuner/CustomizeActions.cs			\
	$(MONO_TUNER)/Mono.Tuner/Dispatcher.cs				\
	$(MONO_TUNER)/Mono.Tuner/Extensions.cs				\
	$(MONO_TUNER)/Mono.Tuner/FixModuleFlags.cs			\
	$(MONO_TUNER)/Mono.Tuner/PreserveSoapHttpClients.cs		\
	$(MONO_TUNER)/Mono.Tuner/Profile.cs				\
	$(MONO_TUNER)/Mono.Tuner/RemoveAttributesBase.cs		\
	$(MONO_TUNER)/Mono.Tuner/RemoveResources.cs			\
	$(MONO_TUNER)/Mono.Tuner/RemoveSecurity.cs			\
	$(LINKER_DIR)/MonoTouch.Tuner/Extensions.cs			\
	$(LINKER_DIR)/MonoTouch.Tuner/ListExportedSymbols.cs	\
	$(LINKER_DIR)/MonoTouch.Tuner/MetadataReducerSubStep.cs	\
	$(LINKER_DIR)/MonoTouch.Tuner/MonoTouchMarkStep.cs		\
	$(LINKER_DIR)/MonoTouch.Tuner/MonoTouchProfile.cs		\
	$(LINKER_DIR)/MonoTouch.Tuner/MonoTouchSweepStep.cs		\
	$(LINKER_DIR)/MonoTouch.Tuner/MonoTouchTypeMap.cs		\
	$(LINKER_DIR)/MonoTouch.Tuner/OptimizeGeneratedCodeSubStep.cs	\
	$(LINKER_DIR)/MonoTouch.Tuner/PreserveCode.cs			\
	$(LINKER_DIR)/MonoTouch.Tuner/ProcessExportedFields.cs	\
	$(LINKER_DIR)/MonoTouch.Tuner/RemoveAttributes.cs		\
	$(LINKER_DIR)/MonoTouch.Tuner/RemoveCode.cs			\
	$(LINKER_DIR)/MonoTouch.Tuner/RemoveExtraRegistrar.cs		\
	$(LINKER_DIR)/MonoTouch.Tuner/RemoveMonoTouchResources.cs	\
	$(LINKER_DIR)/MonoTouch.Tuner/SealerSubStep.cs	\
	$(TOP)/tools/linker/ApplyPreserveAttribute.cs 		\
	$(TOP)/tools/linker/BaseProfile.cs			\
	$(TOP)/tools/linker/CoreHttpMessageHandler.cs	\
	$(TOP)/tools/linker/CoreTlsProviderStep.cs		\
	$(TOP)/tools/linker/CoreMarkStep.cs			\
	$(TOP)/tools/linker/CoreOptimizeGeneratedCode.cs	\
	$(TOP)/tools/linker/CorePreserveCode.cs		\
	$(TOP)/tools/linker/CoreRemoveAttributes.cs		\
	$(TOP)/tools/linker/CoreRemoveSecurity.cs		\
	$(TOP)/tools/linker/MarkNSObjects.cs			\
	$(TOP)/tools/linker/MobileExtensions.cs		\
	$(TOP)/tools/linker/MobileMarkStep.cs			\
	$(TOP)/tools/linker/MobileProfile.cs			\
	$(TOP)/tools/linker/MobileRemoveAttributes.cs		\
	$(TOP)/tools/linker/MobileResolveMainAssemblyStep.cs	\
	$(TOP)/tools/linker/MobileSweepStep.cs			\
	$(TOP)/tools/linker/ObjCExtensions.cs			\
	$(TOP)/tools/linker/RemoveSelectors.cs


COMMON_SOURCES = 											\
	$(TOP)/src/build/ios/Constants.cs						\
	error.cs \
	$(TOP)/src/ObjCRuntime/ErrorHelper.cs			\
	$(MONO_DIR)/mcs/class/Mono.Options/Mono.Options/Options.cs

MTOUCH_SOURCES = \
	$(COMMON_SOURCES)	\
	$(LINKER_SOURCES)	\
	$(TOP)/src/ObjCRuntime/ArgumentSemantic.cs	\
	$(TOP)/src/ObjCRuntime/LinkWithAttribute.cs	\
	$(TOP)/src/ObjCRuntime/NativeAttribute.cs	\
	$(TOP)/src/ObjCRuntime/PlatformAvailability2.cs	\
	$(TOP)/src/ObjCRuntime/ObjectWrapper.cs	\
	Application.cs			\
	Assembly.cs			\
	$(TOP)/tools/common/cache.cs			\
	$(TOP)/tools/common/Driver.cs		\
	$(TOP)/tools/common/Frameworks.cs	\
	$(TOP)/tools/common/MachO.cs		\
	mtouch.cs		\
	OldStaticRegistrar.cs		\
	$(TOP)/tools/common/TargetFramework.cs	\
	$(TOP)/tools/common/StaticRegistrar.cs	\
	$(TOP)/src/ObjCRuntime/Registrar.core.cs	\
	$(TOP)/src/ObjCRuntime/Registrar.cs	\
	$(TOP)/src/ObjCRuntime/RuntimeOptions.cs \
	Tuning.cs	\
	Stripper.cs	\
	AssemblyResolver.cs	\
	Target.cs		\
	SdkVersions.cs \
	BitcodeConverter.cs	\
	$(TOP)/tools/common/Application.cs \
	$(TOP)/tools/common/Assembly.cs \
	$(TOP)/tools/common/Target.cs \
	$(TOP)/tools/common/CompilerFlags.cs \
	$(TOP)/src/Foundation/ExportAttribute.cs \
	$(TOP)/src/Foundation/ConnectAttribute.cs \
	$(XAMARIN_MACDEV_PATH)/Xamarin.MacDev/PListObject.cs \

CECIL_CONFIG=net_4_0_Debug
MONO_CECIL_DLL=$(CECIL_DIR)/bin/$(CECIL_CONFIG)/Mono.Cecil.dll
MONO_CECIL_MDB_DLL=$(CECIL_DIR)/bin/$(CECIL_CONFIG)/Mono.Cecil.Mdb.dll

$(MONO_CECIL_DLL): $(CECIL_PATH)/Mono.Cecil.csproj
	$(Q_XBUILD) cd $(CECIL_DIR) && $(SYSTEM_XBUILD) /p:Configuration=$(CECIL_CONFIG) Mono.Cecil.csproj $(XBUILD_VERBOSITY)

$(MONO_CECIL_MDB_DLL): $(MONO_CECIL_DLL) $(CECIL_PATH)/symbols/mdb/Mono.Cecil.Mdb.csproj
	$(Q_XBUILD) cd $(CECIL_DIR) && $(SYSTEM_XBUILD) /p:Configuration=$(CECIL_CONFIG) symbols/mdb/Mono.Cecil.Mdb.csproj $(XBUILD_VERBOSITY)

SIMLAUNCHERS = simlauncher-sgen simlauncher32-sgen simlauncher64-sgen

monotouch-fixes.i386.dylib: monotouch-fixes.c Makefile
	$(SIMULATOR_CCOMPILE) -DDEBUG -Wl,-headerpad_max_install_names -g -dynamiclib -gdwarf-2 -I$(TOP)/runtime/.libs -L$(TOP)/runtime/.libs $(SIMULATOR86_CFLAGS) monotouch-fixes.c -o $@ -Wall

monotouch-fixes.x86_64.dylib: monotouch-fixes.c Makefile
	$(SIMULATOR_CCOMPILE) -DDEBUG -Wl,-headerpad_max_install_names -g -dynamiclib -gdwarf-2 -I$(TOP)/runtime/.libs -L$(TOP)/runtime/.libs $(SIMULATOR64_CFLAGS) monotouch-fixes.c -o $@ -Wall

monotouch-fixes.dylib: monotouch-fixes.i386.dylib monotouch-fixes.x86_64.dylib
	$(Q_LIPO) lipo -create -output $@ $^

# keep in sync with mtouch.cs (but keep current differences too)
UNREFERENCED_SYMBOLS = 							\
	_xamarin_init_nsthread						\
	_xamarin_get_block_descriptor				\
	_xamarin_get_locale_country_code			\
	_xamarin_log								\
	_xamarin_start_wwan							\
	_xamarin_timezone_get_data					\
	_xamarin_timezone_get_names					\
	_xamarin_IntPtr_objc_msgSend_IntPtr			\
	_xamarin_IntPtr_objc_msgSendSuper_IntPtr	\
	_xamarin_release_managed_ref				\
	_xamarin_create_managed_ref					\
	_CloseZStream								\
	_CreateZStream								\
	_Flush										\
	_ReadZStream								\
	_WriteZStream

# The frameworks order is important as some symbols can be duplicated 
# e.g. NSURLResponse is both in CFNetwork and Foundation in iOS8 but linking to
# CFNetwork will result in binaries that won't work with earlier iOS versions
SIMLAUNCHER_FRAMEWORKS =  \
	-framework CoreFoundation		\
	-framework CoreGraphics			\
	-framework Foundation			\
	-framework AVFoundation			\
	-framework Accelerate			\
	-framework AddressBook			\
	-framework AddressBookUI		\
	-framework AudioToolbox			\
	-framework CFNetwork			\
	-framework CoreAudio			\
	-framework CoreData			\
	-framework CoreLocation			\
	-framework CoreText			\
	-framework ExternalAccessory		\
	-framework GameKit				\
	-framework IOKit			\
	-framework MapKit			\
	-framework MediaPlayer			\
	-framework MessageUI			\
	-framework MobileCoreServices		\
	-framework OpenAL			\
	-framework OpenGLES			\
	-framework StoreKit			\
	-framework SystemConfiguration		\
	-framework UIKit			\
						\
	-weak_framework AssetsLibrary		\
	-weak_framework CoreMedia		\
	-weak_framework CoreMidi		\
	-weak_framework CoreMotion		\
	-weak_framework CoreTelephony		\
	-weak_framework CoreVideo		\
	-weak_framework EventKit		\
	-weak_framework EventKitUI		\
	-weak_framework ImageIO			\
	-weak_framework Security		\
	-weak_framework QuickLook		\
	-weak_framework iAd			\
	-weak_framework Accounts		\
	-weak_framework GLKit			\
	-weak_framework NewsstandKit		\
	-weak_framework CoreImage		\
	-weak_framework CoreBluetooth		\
	-weak_framework Twitter			\
	-weak_framework PassKit			\
	-weak_framework Social			\
	-weak_framework AdSupport		\
	-weak_framework JavaScriptCore		\
	-weak_framework MultipeerConnectivity	\
	-weak_framework SafariServices		\
	-weak_framework SpriteKit		\
						\
	-weak_framework HomeKit			\
	-weak_framework HealthKit		\
	-weak_framework LocalAuthentication	\
	-weak_framework NotificationCenter	\
	-weak_framework PushKit			\
	-weak_framework Photos			\
	-weak_framework PhotosUI		\
	-weak_framework SceneKit		\
	-weak_framework CloudKit		\
	-weak_framework AVKit			\
	-weak_framework WebKit			\
	-weak_framework NetworkExtension	\
	-weak_framework Metal				\
	-weak_framework CoreAudioKit		\
						\
	-weak_framework WatchKit		\
						\
	-weak_framework ReplayKit					\
	-weak_framework Contacts					\
	-weak_framework ContactsUI					\
	-weak_framework CoreSpotlight				\
	-weak_framework WatchConnectivity			\
	-weak_framework ModelIO						\
	-weak_framework GameplayKit					\
						\
	-weak_framework HealthKitUI

# note: there _was_ no CoreAudioKit.framework or Metal.framework for the simulator (before recent iOS9 betas)
# note 2: there's no GameKit, in iOS 9 (beta 3 at least), you're supposed to reference GameCenter instead (looks fixed in beta 4)
# note 3: there's no MetalKit or MetalPerformanceShaders in iOS 9 beta 4 - but other frameworks were added
# note 4: GameCenter was removed in Xcode 7 beta 5, and GameKit is back.

# keep the above list of weak_framework in sync with mtouch.cs
# except it is no a mistake that GameController and MediaAccessibility (#13636) are not built into simlauncher

define SimlauncherTemplate

simlauncher$(5)$(1): simlauncher.m $(TOP)/runtime/.libs/ios/libxamarin.a $(BUILD_DESTDIR)/simulator$(4)/lib/libmono$(3)-2.0.a Makefile Xamarin.iOS.registrar.ios.a
	$(QT_CC) $(SIMULATOR_CC) -DDEBUG -DSIMLAUNCHER $(2) -gdwarf-2 \
		-L$(TOP)/runtime/.libs/ios \
		-L$(BUILD_DESTDIR)/simulator$(4)/lib/ \
		-I$(TOP)/runtime \
		-I$(BUILD_DESTDIR)/simulator$(4)/include/mono-2.0 \
		-I$(TOP)/builds/simulator$(4)/eglib/src \
		-I$(MONO_PATH)/eglib/src \
		$(BUILD_DESTDIR)/simulator$(4)/lib/libmono$(3)-2.0.a \
		$(foreach u,$(UNREFERENCED_SYMBOLS),-u $u)  \
		$(TOP)/runtime/.libs/ios/libapp.a \
		-Wl,-w \
		-lz -liconv $(TOP)/runtime/.libs/ios/libxamarin-debug.a simlauncher.m $(SIMLAUNCHER_FRAMEWORKS) $(SIMULATOR$(4)_OBJC_CFLAGS) -o $$@

endef

$(eval $(call SimlauncherTemplate,-sgen,$(BUILD_DESTDIR)/simulator86/lib/libmono-profiler-log.a -u _mono_profiler_startup,sgen,86,))
$(eval $(call SimlauncherTemplate,-sgen,$(BUILD_DESTDIR)/simulator86/lib/libmono-profiler-log.a -u _mono_profiler_startup -DXAMCORE_2_0 Xamarin.iOS.registrar.ios.a,sgen,86,32))
$(eval $(call SimlauncherTemplate,-sgen,$(BUILD_DESTDIR)/simulator64/lib/libmono-profiler-log.a -u _mono_profiler_startup -DXAMCORE_2_0 Xamarin.iOS.registrar.ios.a,sgen,64,64))

IOS_DEFINES = -d:MONOTOUCH -d:MTOUCH $(APPLETLS_DEFINES)

MTOUCH_COMPILE_DEPS = $(MTOUCH_SOURCES) $(MONO_CECIL_DLL) $(MONO_CECIL_MDB_DLL) Makefile $(LINKER_RESOURCES)
MTOUCH_COMPILE_ARGS = -unsafe $(IOS_DEFINES) -resource:Info.plist.tmpl -r:$(MONO_CECIL_DLL) -r:$(MONO_CECIL_MDB_DLL) $(MTOUCH_SOURCES) -nowarn:0436 $(LINKER_RESOURCES:%=-resource:%)

# bin/Debug/mtouch.exe is used from mtouch.csproj when debugging
bin/Debug/mtouch.exe: $(MTOUCH_COMPILE_DEPS)
	$(Q) mkdir -p bin/Debug
	$(Q) $(SYSTEM_MCS) $(MTOUCH_COMPILE_ARGS) -out:$@ -debug -d:DEV

SdkVersions.cs: SdkVersions.cs.in Makefile $(TOP)/Make.config
	$(Q_GEN) sed \
		-e 's/@IOS_SDK_VERSION@/$(IOS_SDK_VERSION)/g' -e 's/@WATCHOS_SDK_VERSION@/$(WATCH_SDK_VERSION)/' -e 's/@TVOS_SDK_VERSION@/$(TVOS_SDK_VERSION)/' -e 's/@OSX_SDK_VERSION@/$(OSX_SDK_VERSION)/' \
		-e 's/@MIN_IOS_SDK_VERSION@/$(MIN_IOS_SDK_VERSION)/g' -e 's/@MIN_WATCHOS_SDK_VERSION@/$(MIN_WATCHOS_SDK_VERSION)/' -e 's/@MIN_TVOS_SDK_VERSION@/$(MIN_TVOS_SDK_VERSION)/' -e 's/@MIN_OSX_SDK_VERSION@/$(MIN_OSX_SDK_VERSION)/' \
		-e 's/@XCODE_VERSION@/$(XCODE_VERSION)/g' \
		$< > $@ 

# bin/Makefile/mtouch.exe is what we build from the makefile (and end up releasing)
bin/Makefile/mtouch.exe: $(MTOUCH_COMPILE_DEPS)
	$(Q) mkdir -p $(dir $@)
	$(Q_MCS) $(SYSTEM_MCS) $(MTOUCH_COMPILE_ARGS) -out:$@

INSTALLED_MTOUCH = \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin/mtouch \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch/mtouch.exe \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch/Mono.Cecil.dll \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch/Mono.Cecil.Mdb.dll \

%.registrar.ios.m:     $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mono/Xamarin.iOS/%.dll     $(INSTALLED_MTOUCH)
	$(Q_GEN) $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin/mtouch -q --runregistrar:$(abspath $@) --sdkroot $(XCODE_DEVELOPER_ROOT) --sdk $(IOS_SDK_VERSION)   $< --registrar:static --target-framework Xamarin.iOS,v1.0    --abi i386,x86_64
	$(Q) touch $@

%.registrar.watchos.m: $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mono/Xamarin.WatchOS/%.dll $(INSTALLED_MTOUCH)
	$(Q_GEN) $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin/mtouch -q --runregistrar:$(abspath $@) --sdkroot $(XCODE_DEVELOPER_ROOT) --sdk $(WATCH_SDK_VERSION) $< --registrar:static --target-framework Xamarin.WatchOS,1.0 --abi i386
	$(Q) touch $@

%.registrar.tvos.m:    $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mono/Xamarin.TVOS/%.dll    $(INSTALLED_MTOUCH)
	$(Q_GEN) $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin/mtouch -q --runregistrar:$(abspath $@) --sdkroot $(XCODE_DEVELOPER_ROOT) --sdk $(TVOS_SDK_VERSION)  $< --registrar:static --target-framework Xamarin.TVOS,1.0    --abi x86_64
	$(Q) touch $@

%.registrar.ios.a:        %.registrar.ios.i386.a %.registrar.ios.x86_64.a
	$(Q_LIPO) $(DEVICE_BIN_PATH)/lipo -create -output $@ $^

%.registrar.ios.i386.a:   %.registrar.ios.m
	$(Q_CC) $(IOS_CC) -DDEBUG -g -gdwarf-2 $(SIMULATOR86_CFLAGS)    -x objective-c++ -o $@ -c $^ -Wall -I$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/SDKs/MonoTouch.iphonesimulator.sdk/usr/include

%.registrar.ios.x86_64.a: %.registrar.ios.m
	$(Q_CC) $(IOS_CC) -DDEBUG -g -gdwarf-2 $(SIMULATOR64_CFLAGS)    -x objective-c++ -o $@ -c $^ -Wall -I$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/SDKs/MonoTouch.iphonesimulator.sdk/usr/include

%.registrar.watchos.a:    %.registrar.watchos.m
	$(Q_CC) $(IOS_CC) -DDEBUG -g -gdwarf-2 $(SIMULATORWATCH_CFLAGS) -x objective-c++ -o $@ -c $^ -Wall -I$(IOS_DESTDIR)$(XAMARIN_WATCHSIMULATOR_SDK)/usr/include

%.registrar.tvos.a:       %.registrar.tvos.m
	$(Q_CC) $(IOS_CC) -DDEBUG -g -gdwarf-2 $(SIMULATORTV_CFLAGS)    -x objective-c++ -o $@ -c $^ -Wall -I$(IOS_DESTDIR)$(XAMARIN_TVSIMULATOR_SDK)/usr/include

TARGETS = \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin/mtouch                                          \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch/mtouch.exe                               \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch/Mono.Cecil.dll                           \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch/Mono.Cecil.Mdb.dll                       \
	$(foreach launcher,$(SIMLAUNCHERS),$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin/$(launcher)) \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/monotouch-fixes.dylib                           \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/SDKs/MonoTouch.iphonesimulator.sdk/usr/lib/Xamarin.iOS.registrar.a         \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/SDKs/MonoTouch.iphonesimulator.sdk/usr/lib/MonoTouch.Dialog-1.registrar.a  \
#	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/SDKs/MonoTouch.iphonesimulator.sdk/usr/lib/MonoTouch.NUnitLite.registrar.a \

ifdef INCLUDE_WATCH
TARGETS += $(IOS_DESTDIR)$(XAMARIN_WATCHSIMULATOR_SDK)/usr/lib/Xamarin.WatchOS.registrar.a
endif

ifdef INCLUDE_TVOS
TARGETS +=	\
	$(IOS_DESTDIR)$(XAMARIN_TVSIMULATOR_SDK)/usr/lib/Xamarin.TVOS.registrar.a       \
#	$(IOS_DESTDIR)$(XAMARIN_TVSIMULATOR_SDK)/usr/lib/MonoTouch.Dialog-1.registrar.a
endif

TARGET_DIRS = \
	bin/Makefile                                                 \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin                        \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib                        \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch                 \
	$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/etc/mono/assemblies/System \
	$(IOS_DESTDIR)$(MONOTOUCH_SIMULATOR_SDK)/usr/lib             \
	$(IOS_DESTDIR)$(XAMARIN_WATCHSIMULATOR_SDK)/usr/lib          \
	$(IOS_DESTDIR)$(XAMARIN_TVSIMULATOR_SDK)/usr/lib             \

$(TARGET_DIRS):
	$(Q) mkdir -p $@

$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch/mtouch.exe: bin/Makefile/mtouch.exe | $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch
	$(Q) cp $<* $(dir $@)

$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch/Mono.Cecil.dll: $(MONO_CECIL_DLL) | $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch
	$(Q) cp $<* $(dir $@)

$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch/Mono.Cecil.Mdb.dll: $(MONO_CECIL_MDB_DLL) | $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/mtouch
	$(Q) cp $<* $(dir $@)

$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin/mtouch: mtouch.in | $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin
	$(Q_GEN) sed 's!@MONOTOUCH_PREFIX@!$(abspath $(IOS_TARGETDIR)$(MONOTOUCH_PREFIX))!g' $< > $@
	$(Q) chmod +x $@

$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin/%: % | $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/bin
	$(Q) cp $< $@

$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/%: % | $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib
	$(Q) cp $< $@

$(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib/monotouch-fixes.dylib: monotouch-fixes.dylib | $(IOS_DESTDIR)$(MONOTOUCH_PREFIX)/lib
	$(Q) cp $< $@
	$(Q) install_name_tool -id $(IOS_TARGETDIR)$(MONOTOUCH_PREFIX)/lib/monotouch-fixes.dylib $@

$(IOS_DESTDIR)$(MONOTOUCH_SIMULATOR_SDK)/usr/lib/%.registrar.a: %.registrar.ios.a | $(IOS_DESTDIR)$(MONOTOUCH_SIMULATOR_SDK)/usr/lib
	$(Q) cp $< $@

$(IOS_DESTDIR)$(XAMARIN_WATCHSIMULATOR_SDK)/usr/lib/%.registrar.a: %.registrar.watchos.a | $(IOS_DESTDIR)$(XAMARIN_WATCHSIMULATOR_SDK)/usr/lib
	$(Q) cp $< $@

$(IOS_DESTDIR)$(XAMARIN_TVSIMULATOR_SDK)/usr/lib/%.registrar.a: %.registrar.tvos.a | $(IOS_DESTDIR)$(XAMARIN_TVSIMULATOR_SDK)/usr/lib
	$(Q) cp $< $@

ifdef INCLUDE_IOS
install-local:: $(TARGETS)
all-local:: $(TARGETS)
endif

clean-local::
	rm -f bin obj
	rm -f $(SIMLAUNCHERS)
	$(SYSTEM_XBUILD) /t:Clean /p:Configuration=$(CECIL_CONFIG) $(CECIL_PATH)/Mono.Cecil.csproj
	$(SYSTEM_XBUILD) /t:Clean /p:Configuration=$(CECIL_CONFIG) $(CECIL_PATH)/symbols/mdb/Mono.Cecil.Mdb.csproj

include $(TOP)/mk/rules.mk

# make will automatically consider files created in chained implicit rules as temporary files, and delete them afterwards
# marking those files as .SECONDARY will prevent that deletion.
.SECONDARY: $(foreach file,Xamarin.iOS MonoTouch.Dialog-1 MonoTouch.NUnitLite,$(file).registrar.ios.a $(file).registrar.ios.i386.a $(file).registrar.ios.x86_64.a $(file).registrar.ios.m)
.SECONDARY: $(foreach file,Xamarin.WatchOS,$(file).registrar.watchos.a $(file).registrar.watchos.m)
.SECONDARY: $(foreach file,Xamarin.TVOS MonoTouch.Dialog-1,$(file).registrar.tvos.a $(file).registrar.tvos.m)