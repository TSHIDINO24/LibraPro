; ModuleID = 'obj\Release\130\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Release\130\android\marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [150 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 7
	i64 232391251801502327, ; 1: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 41
	i64 702024105029695270, ; 2: System.Drawing.Common => 0x9be17343c0e7726 => 70
	i64 720058930071658100, ; 3: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 35
	i64 872800313462103108, ; 4: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 33
	i64 996343623809489702, ; 5: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 51
	i64 1000557547492888992, ; 6: Mono.Security.dll => 0xde2b1c9cba651a0 => 73
	i64 1120440138749646132, ; 7: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 56
	i64 1425944114962822056, ; 8: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 1
	i64 1624659445732251991, ; 9: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 26
	i64 1731380447121279447, ; 10: Newtonsoft.Json => 0x18071957e9b889d7 => 10
	i64 1795316252682057001, ; 11: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 27
	i64 1836611346387731153, ; 12: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 41
	i64 1837131419302612636, ; 13: Xamarin.Google.Android.DataTransport.TransportBackendCct.dll => 0x197ecd4ad53dce9c => 54
	i64 1865037103900624886, ; 14: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 5
	i64 1981742497975770890, ; 15: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 38
	i64 2040001226662520565, ; 16: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 74
	i64 2064708342624596306, ; 17: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 65
	i64 2133195048986300728, ; 18: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 10
	i64 2165725771938924357, ; 19: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 28
	i64 2262844636196693701, ; 20: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 33
	i64 2287887973817120656, ; 21: System.ComponentModel.DataAnnotations.dll => 0x1fc035fd8d41f790 => 72
	i64 2329709569556905518, ; 22: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 37
	i64 2335503487726329082, ; 23: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 21
	i64 2337758774805907496, ; 24: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 20
	i64 2470498323731680442, ; 25: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 30
	i64 2547086958574651984, ; 26: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 25
	i64 2592350477072141967, ; 27: System.Xml.dll => 0x23f9e10627330e8f => 23
	i64 2624866290265602282, ; 28: mscorlib.dll => 0x246d65fbde2db8ea => 8
	i64 2668049510182046531, ; 29: MvvmHelpers => 0x2506d0e4c18e4b43 => 9
	i64 2783046991838674048, ; 30: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 20
	i64 2960931600190307745, ; 31: Xamarin.Forms.Core => 0x2917579a49927da1 => 49
	i64 3017704767998173186, ; 32: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 56
	i64 3143515969535650208, ; 33: Xamarin.Firebase.Encoders => 0x2ba0031e85f0a9a0 => 46
	i64 3289520064315143713, ; 34: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 36
	i64 3344514922410554693, ; 35: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 68
	i64 3411255996856937470, ; 36: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 59
	i64 3522470458906976663, ; 37: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 42
	i64 3531994851595924923, ; 38: System.Numerics => 0x31042a9aade235bb => 19
	i64 3727469159507183293, ; 39: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 40
	i64 4247996603072512073, ; 40: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 60
	i64 4310591779499177988, ; 41: Microsoft.Toolkit.Mvvm => 0x3bd24c628cc47804 => 6
	i64 4335356748765836238, ; 42: Xamarin.Google.Android.DataTransport.TransportBackendCct => 0x3c2a47fe48c7b3ce => 54
	i64 4523676002271688167, ; 43: MvvmHelpers.dll => 0x3ec7535b4a5cf5e7 => 9
	i64 4525561845656915374, ; 44: System.ServiceModel.Internals => 0x3ece06856b710dae => 71
	i64 4636684751163556186, ; 45: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 43
	i64 4794310189461587505, ; 46: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 25
	i64 4795410492532947900, ; 47: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 42
	i64 5142919913060024034, ; 48: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 50
	i64 5203618020066742981, ; 49: Xamarin.Essentials => 0x4836f704f0e652c5 => 45
	i64 5507995362134886206, ; 50: System.Core.dll => 0x4c705499688c873e => 15
	i64 6085203216496545422, ; 51: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 51
	i64 6086316965293125504, ; 52: FormsViewGroup.dll => 0x5476f10882baef80 => 3
	i64 6222399776351216807, ; 53: System.Text.Json.dll => 0x565a67a0ffe264a7 => 22
	i64 6401687960814735282, ; 54: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 37
	i64 6504860066809920875, ; 55: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 28
	i64 6548213210057960872, ; 56: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 32
	i64 6589202984700901502, ; 57: Xamarin.Google.ErrorProne.Annotations.dll => 0x5b718d34180a787e => 57
	i64 6659513131007730089, ; 58: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 35
	i64 6876862101832370452, ; 59: System.Xml.Linq => 0x5f6f85a57d108914 => 24
	i64 6878582369430612696, ; 60: Xamarin.Google.Android.DataTransport.TransportRuntime.dll => 0x5f75a238802d2ad8 => 55
	i64 7026573318513401069, ; 61: Xamarin.Firebase.Encoders.Proto.dll => 0x618367346e3a9ced => 47
	i64 7488575175965059935, ; 62: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 24
	i64 7635363394907363464, ; 63: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 49
	i64 7637365915383206639, ; 64: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 45
	i64 7654504624184590948, ; 65: System.Net.Http => 0x6a3a4366801b8264 => 17
	i64 7735352534559001595, ; 66: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 64
	i64 7820441508502274321, ; 67: System.Data => 0x6c87ca1e14ff8111 => 69
	i64 7836164640616011524, ; 68: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 26
	i64 8083354569033831015, ; 69: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 36
	i64 8085230611270010360, ; 70: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 18
	i64 8167236081217502503, ; 71: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 4
	i64 8187640529827139739, ; 72: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 67
	i64 8318905602908530212, ; 73: System.ComponentModel.DataAnnotations => 0x7372b092055ea624 => 72
	i64 8465511506719290632, ; 74: Xamarin.Firebase.Messaging.dll => 0x757b89dcf7fc3508 => 48
	i64 8626175481042262068, ; 75: Java.Interop => 0x77b654e585b55834 => 4
	i64 8844506025403580595, ; 76: Plugin.FirebasePushNotification => 0x7abdff5eb1fb80b3 => 11
	i64 8853378295825400934, ; 77: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 63
	i64 9324707631942237306, ; 78: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 27
	i64 9662334977499516867, ; 79: System.Numerics.dll => 0x8617827802b0cfc3 => 19
	i64 9678050649315576968, ; 80: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 30
	i64 9704315356731487263, ; 81: Plugin.FirebasePushNotification.dll => 0x86aca766ba59341f => 11
	i64 9735414641753518179, ; 82: Xamarin.Firebase.Encoders.Proto => 0x871b240946daf063 => 47
	i64 9808709177481450983, ; 83: Mono.Android.dll => 0x881f890734e555e7 => 7
	i64 9998632235833408227, ; 84: Mono.Security => 0x8ac2470b209ebae3 => 73
	i64 10038780035334861115, ; 85: System.Net.Http.dll => 0x8b50e941206af13b => 17
	i64 10226222362177979215, ; 86: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 65
	i64 10229024438826829339, ; 87: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 32
	i64 10321854143672141184, ; 88: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 62
	i64 10406448008575299332, ; 89: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 68
	i64 10430153318873392755, ; 90: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 31
	i64 10447083246144586668, ; 91: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 5
	i64 11023048688141570732, ; 92: System.Core => 0x98f9bc61168392ac => 15
	i64 11037814507248023548, ; 93: System.Xml => 0x992e31d0412bf7fc => 23
	i64 11071824625609515081, ; 94: Xamarin.Google.ErrorProne.Annotations => 0x99a705d600e0a049 => 57
	i64 11162124722117608902, ; 95: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 44
	i64 11360823163839134928, ; 96: App2.Android => 0x9da9c079aca93cd0 => 0
	i64 11529969570048099689, ; 97: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 44
	i64 12102847907131387746, ; 98: System.Buffers => 0xa7f5f40c43256f62 => 14
	i64 12145679461940342714, ; 99: System.Text.Json => 0xa88e1f1ebcb62fba => 22
	i64 12346958216201575315, ; 100: Xamarin.JavaX.Inject.dll => 0xab593514a5491b93 => 61
	i64 12451044538927396471, ; 101: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 34
	i64 12466513435562512481, ; 102: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 39
	i64 12538491095302438457, ; 103: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 29
	i64 12828192437253469131, ; 104: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 66
	i64 12854524964145442905, ; 105: Xamarin.Firebase.Encoders.dll => 0xb26472594447b059 => 46
	i64 12963446364377008305, ; 106: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 70
	i64 13196197655982686080, ; 107: Prism => 0xb7224fda06b0bf80 => 13
	i64 13370592475155966277, ; 108: System.Runtime.Serialization => 0xb98de304062ea945 => 1
	i64 13454009404024712428, ; 109: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 58
	i64 13465488254036897740, ; 110: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 64
	i64 13572454107664307259, ; 111: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 40
	i64 13647894001087880694, ; 112: System.Data.dll => 0xbd670f48cb071df6 => 69
	i64 13828521679616088467, ; 113: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 63
	i64 13959074834287824816, ; 114: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 34
	i64 13967638549803255703, ; 115: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 50
	i64 14124974489674258913, ; 116: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 29
	i64 14524915121004231475, ; 117: Xamarin.JavaX.Inject => 0xc992dd58a4283b33 => 61
	i64 14551742072151931844, ; 118: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 21
	i64 14792063746108907174, ; 119: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 58
	i64 14958496593779620648, ; 120: App2 => 0xcf974166061ffb28 => 2
	i64 15024878362326791334, ; 121: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 18
	i64 15279429628684179188, ; 122: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 67
	i64 15370334346939861994, ; 123: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 31
	i64 15609085926864131306, ; 124: System.dll => 0xd89e9cf3334914ea => 16
	i64 15644590034465900806, ; 125: Microsoft.Toolkit.Mvvm.dll => 0xd91cbfbf6cf4c906 => 6
	i64 15810740023422282496, ; 126: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 52
	i64 15930129725311349754, ; 127: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 60
	i64 15963349826457351533, ; 128: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 74
	i64 16035518054986892682, ; 129: Prism.dll => 0xde899ab610db458a => 13
	i64 16154507427712707110, ; 130: System => 0xe03056ea4e39aa26 => 16
	i64 16381405407414385978, ; 131: Plugin.Settings => 0xe356716cf698fd3a => 12
	i64 16423015068819898779, ; 132: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 66
	i64 16467346005009053642, ; 133: Xamarin.Google.Android.DataTransport.TransportApi => 0xe487c3f19e0337ca => 53
	i64 16833383113903931215, ; 134: mscorlib => 0xe99c30c1484d7f4f => 8
	i64 16973888863008331153, ; 135: Plugin.Settings.dll => 0xeb8f5dfd48921591 => 12
	i64 17229931436468516663, ; 136: App2.dll => 0xef1d035a770ab737 => 2
	i64 17434242208926550937, ; 137: Xamarin.Google.Android.DataTransport.TransportRuntime => 0xf1f2deeb1f304b99 => 55
	i64 17704177640604968747, ; 138: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 39
	i64 17710060891934109755, ; 139: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 38
	i64 17838668724098252521, ; 140: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 14
	i64 17882897186074144999, ; 141: FormsViewGroup => 0xf82cd03e3ac830e7 => 3
	i64 17891337867145587222, ; 142: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 62
	i64 17892495832318972303, ; 143: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 52
	i64 17945795017270165205, ; 144: Xamarin.Google.Android.DataTransport.TransportApi.dll => 0xf90c457cc05cfed5 => 53
	i64 17986907704309214542, ; 145: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 59
	i64 18129453464017766560, ; 146: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 71
	i64 18337470502355292274, ; 147: Xamarin.Firebase.Messaging => 0xfe7bc8440c175072 => 48
	i64 18354825640458385537, ; 148: App2.Android.dll => 0xfeb970ac05c0f881 => 0
	i64 18380184030268848184 ; 149: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 43
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [150 x i32] [
	i32 7, i32 41, i32 70, i32 35, i32 33, i32 51, i32 73, i32 56, ; 0..7
	i32 1, i32 26, i32 10, i32 27, i32 41, i32 54, i32 5, i32 38, ; 8..15
	i32 74, i32 65, i32 10, i32 28, i32 33, i32 72, i32 37, i32 21, ; 16..23
	i32 20, i32 30, i32 25, i32 23, i32 8, i32 9, i32 20, i32 49, ; 24..31
	i32 56, i32 46, i32 36, i32 68, i32 59, i32 42, i32 19, i32 40, ; 32..39
	i32 60, i32 6, i32 54, i32 9, i32 71, i32 43, i32 25, i32 42, ; 40..47
	i32 50, i32 45, i32 15, i32 51, i32 3, i32 22, i32 37, i32 28, ; 48..55
	i32 32, i32 57, i32 35, i32 24, i32 55, i32 47, i32 24, i32 49, ; 56..63
	i32 45, i32 17, i32 64, i32 69, i32 26, i32 36, i32 18, i32 4, ; 64..71
	i32 67, i32 72, i32 48, i32 4, i32 11, i32 63, i32 27, i32 19, ; 72..79
	i32 30, i32 11, i32 47, i32 7, i32 73, i32 17, i32 65, i32 32, ; 80..87
	i32 62, i32 68, i32 31, i32 5, i32 15, i32 23, i32 57, i32 44, ; 88..95
	i32 0, i32 44, i32 14, i32 22, i32 61, i32 34, i32 39, i32 29, ; 96..103
	i32 66, i32 46, i32 70, i32 13, i32 1, i32 58, i32 64, i32 40, ; 104..111
	i32 69, i32 63, i32 34, i32 50, i32 29, i32 61, i32 21, i32 58, ; 112..119
	i32 2, i32 18, i32 67, i32 31, i32 16, i32 6, i32 52, i32 60, ; 120..127
	i32 74, i32 13, i32 16, i32 12, i32 66, i32 53, i32 8, i32 12, ; 128..135
	i32 2, i32 55, i32 39, i32 38, i32 14, i32 3, i32 62, i32 52, ; 136..143
	i32 53, i32 59, i32 71, i32 48, i32 0, i32 43 ; 144..149
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ a200af12c1e846626b8caebd926ac14c185f71ec"}
!llvm.linker.options = !{}
