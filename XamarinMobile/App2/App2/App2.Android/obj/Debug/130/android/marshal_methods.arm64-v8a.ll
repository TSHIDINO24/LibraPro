; ModuleID = 'obj\Debug\130\android\marshal_methods.arm64-v8a.ll'
source_filename = "obj\Debug\130\android\marshal_methods.arm64-v8a.ll"
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
@assembly_image_cache_hashes = local_unnamed_addr constant [268 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 51
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 8
	i64 210515253464952879, ; 2: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 40
	i64 232391251801502327, ; 3: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 74
	i64 295915112840604065, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 75
	i64 316157742385208084, ; 5: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 45
	i64 634308326490598313, ; 6: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 60
	i64 687654259221141486, ; 7: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 108
	i64 702024105029695270, ; 8: System.Drawing.Common => 0x9be17343c0e7726 => 124
	i64 720058930071658100, ; 9: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 54
	i64 872800313462103108, ; 10: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 50
	i64 940822596282819491, ; 11: System.Transactions => 0xd0e792aa81923a3 => 122
	i64 996343623809489702, ; 12: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 100
	i64 1000557547492888992, ; 13: Mono.Security.dll => 0xde2b1c9cba651a0 => 132
	i64 1120440138749646132, ; 14: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 105
	i64 1315114680217950157, ; 15: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 35
	i64 1425944114962822056, ; 16: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 2
	i64 1465843056802068477, ; 17: Xamarin.Firebase.Components.dll => 0x1457b87e6928f7fd => 88
	i64 1624659445732251991, ; 18: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 33
	i64 1628611045998245443, ; 19: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 62
	i64 1636321030536304333, ; 20: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 55
	i64 1731380447121279447, ; 21: Newtonsoft.Json => 0x18071957e9b889d7 => 11
	i64 1743969030606105336, ; 22: System.Memory.dll => 0x1833d297e88f2af8 => 18
	i64 1795316252682057001, ; 23: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 34
	i64 1836611346387731153, ; 24: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 74
	i64 1837131419302612636, ; 25: Xamarin.Google.Android.DataTransport.TransportBackendCct.dll => 0x197ecd4ad53dce9c => 103
	i64 1865037103900624886, ; 26: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 6
	i64 1875917498431009007, ; 27: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 30
	i64 1981742497975770890, ; 28: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 61
	i64 2040001226662520565, ; 29: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 133
	i64 2064708342624596306, ; 30: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x1ca7514c5eecb152 => 117
	i64 2133195048986300728, ; 31: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 11
	i64 2136356949452311481, ; 32: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 66
	i64 2165725771938924357, ; 33: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 38
	i64 2262844636196693701, ; 34: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 50
	i64 2284400282711631002, ; 35: System.Web.Services => 0x1fb3d1f42fd4249a => 128
	i64 2287887973817120656, ; 36: System.ComponentModel.DataAnnotations.dll => 0x1fc035fd8d41f790 => 131
	i64 2329709569556905518, ; 37: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 58
	i64 2335503487726329082, ; 38: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 25
	i64 2337758774805907496, ; 39: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 23
	i64 2470498323731680442, ; 40: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 44
	i64 2479423007379663237, ; 41: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 80
	i64 2497223385847772520, ; 42: System.Runtime => 0x22a7eb7046413568 => 24
	i64 2547086958574651984, ; 43: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 29
	i64 2592350477072141967, ; 44: System.Xml.dll => 0x23f9e10627330e8f => 27
	i64 2624866290265602282, ; 45: mscorlib.dll => 0x246d65fbde2db8ea => 9
	i64 2668049510182046531, ; 46: MvvmHelpers => 0x2506d0e4c18e4b43 => 10
	i64 2694427813909235223, ; 47: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 70
	i64 2783046991838674048, ; 48: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 23
	i64 2787234703088983483, ; 49: Xamarin.AndroidX.Startup.StartupRuntime => 0x26ae3f31ef429dbb => 76
	i64 2960931600190307745, ; 50: Xamarin.Forms.Core => 0x2917579a49927da1 => 98
	i64 3017704767998173186, ; 51: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 105
	i64 3143515969535650208, ; 52: Xamarin.Firebase.Encoders => 0x2ba0031e85f0a9a0 => 90
	i64 3289520064315143713, ; 53: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 57
	i64 3303437397778967116, ; 54: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 31
	i64 3311221304742556517, ; 55: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 22
	i64 3344514922410554693, ; 56: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 120
	i64 3364695309916733813, ; 57: Xamarin.Firebase.Common => 0x2eb1cc8eb5028175 => 87
	i64 3411255996856937470, ; 58: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 109
	i64 3493805808809882663, ; 59: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 78
	i64 3522470458906976663, ; 60: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 77
	i64 3531994851595924923, ; 61: System.Numerics => 0x31042a9aade235bb => 21
	i64 3571415421602489686, ; 62: System.Runtime.dll => 0x319037675df7e556 => 24
	i64 3716579019761409177, ; 63: netstandard.dll => 0x3393f0ed5c8c5c99 => 1
	i64 3727469159507183293, ; 64: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 73
	i64 3772598417116884899, ; 65: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 51
	i64 3966267475168208030, ; 66: System.Memory => 0x370b03412596249e => 18
	i64 4201423742386704971, ; 67: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 45
	i64 4239882675311405204, ; 68: Xamarin.Firebase.Encoders.JSON => 0x3ad716d44f44e894 => 91
	i64 4247996603072512073, ; 69: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 112
	i64 4310591779499177988, ; 70: Microsoft.Toolkit.Mvvm => 0x3bd24c628cc47804 => 7
	i64 4335356748765836238, ; 71: Xamarin.Google.Android.DataTransport.TransportBackendCct => 0x3c2a47fe48c7b3ce => 103
	i64 4523676002271688167, ; 72: MvvmHelpers.dll => 0x3ec7535b4a5cf5e7 => 10
	i64 4525561845656915374, ; 73: System.ServiceModel.Internals => 0x3ece06856b710dae => 129
	i64 4636684751163556186, ; 74: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 82
	i64 4702770163853758138, ; 75: Xamarin.Firebase.Components => 0x4143988c34cf0eba => 88
	i64 4743821336939966868, ; 76: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 130
	i64 4782108999019072045, ; 77: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 37
	i64 4794310189461587505, ; 78: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 29
	i64 4795410492532947900, ; 79: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 77
	i64 5142919913060024034, ; 80: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 99
	i64 5203618020066742981, ; 81: Xamarin.Essentials => 0x4836f704f0e652c5 => 85
	i64 5205316157927637098, ; 82: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 64
	i64 5348796042099802469, ; 83: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 65
	i64 5376510917114486089, ; 84: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 80
	i64 5408338804355907810, ; 85: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 79
	i64 5451019430259338467, ; 86: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 43
	i64 5507995362134886206, ; 87: System.Core.dll => 0x4c705499688c873e => 16
	i64 5574231584441077149, ; 88: Xamarin.AndroidX.Annotation.Jvm => 0x4d5ba617ae5f8d9d => 32
	i64 5692067934154308417, ; 89: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 84
	i64 5757522595884336624, ; 90: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 41
	i64 5814345312393086621, ; 91: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 70
	i64 5896680224035167651, ; 92: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 59
	i64 6085203216496545422, ; 93: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 100
	i64 6086316965293125504, ; 94: FormsViewGroup.dll => 0x5476f10882baef80 => 4
	i64 6092862891035488599, ; 95: Xamarin.Firebase.Measurement.Connector.dll => 0x548e32849d547157 => 96
	i64 6222399776351216807, ; 96: System.Text.Json.dll => 0x565a67a0ffe264a7 => 26
	i64 6319713645133255417, ; 97: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 60
	i64 6401687960814735282, ; 98: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 58
	i64 6504860066809920875, ; 99: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 38
	i64 6548213210057960872, ; 100: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 48
	i64 6554405243736097249, ; 101: Xamarin.GooglePlayServices.Stats => 0x5af5ecd7aad901e1 => 111
	i64 6589202984700901502, ; 102: Xamarin.Google.ErrorProne.Annotations.dll => 0x5b718d34180a787e => 106
	i64 6591024623626361694, ; 103: System.Web.Services.dll => 0x5b7805f9751a1b5e => 128
	i64 6659513131007730089, ; 104: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 54
	i64 6876862101832370452, ; 105: System.Xml.Linq => 0x5f6f85a57d108914 => 28
	i64 6878582369430612696, ; 106: Xamarin.Google.Android.DataTransport.TransportRuntime.dll => 0x5f75a238802d2ad8 => 104
	i64 6894844156784520562, ; 107: System.Numerics.Vectors => 0x5faf683aead1ad72 => 22
	i64 6975328107116786489, ; 108: Xamarin.Firebase.Annotations => 0x60cd57f4e07e7339 => 86
	i64 7026573318513401069, ; 109: Xamarin.Firebase.Encoders.Proto.dll => 0x618367346e3a9ced => 92
	i64 7036436454368433159, ; 110: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 56
	i64 7103753931438454322, ; 111: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 53
	i64 7385250113861300937, ; 112: Xamarin.Firebase.Iid.Interop.dll => 0x667dadd98e1db2c9 => 93
	i64 7476537270401454554, ; 113: Xamarin.Firebase.Encoders.JSON.dll => 0x67c1ff08f83f51da => 91
	i64 7488575175965059935, ; 114: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 28
	i64 7635363394907363464, ; 115: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 98
	i64 7637365915383206639, ; 116: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 85
	i64 7654504624184590948, ; 117: System.Net.Http => 0x6a3a4366801b8264 => 19
	i64 7735352534559001595, ; 118: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 116
	i64 7820441508502274321, ; 119: System.Data => 0x6c87ca1e14ff8111 => 121
	i64 7836164640616011524, ; 120: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 33
	i64 7904570928025870493, ; 121: Xamarin.Firebase.Installations => 0x6db2ad60fadca09d => 94
	i64 7940488133782528123, ; 122: Xamarin.GooglePlayServices.CloudMessaging => 0x6e3247e31d4fe07b => 110
	i64 7969431548154767168, ; 123: Xamarin.Firebase.Installations.dll => 0x6e991bc4e98e6740 => 94
	i64 8044118961405839122, ; 124: System.ComponentModel.Composition => 0x6fa2739369944712 => 127
	i64 8083354569033831015, ; 125: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 57
	i64 8085230611270010360, ; 126: System.Net.Http.Json.dll => 0x703482674fdd05f8 => 20
	i64 8103644804370223335, ; 127: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 123
	i64 8167236081217502503, ; 128: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 5
	i64 8187640529827139739, ; 129: Xamarin.KotlinX.Coroutines.Android => 0x71a057ae90f0109b => 119
	i64 8318905602908530212, ; 130: System.ComponentModel.DataAnnotations => 0x7372b092055ea624 => 131
	i64 8398329775253868912, ; 131: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 42
	i64 8400357532724379117, ; 132: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 69
	i64 8465511506719290632, ; 133: Xamarin.Firebase.Messaging.dll => 0x757b89dcf7fc3508 => 97
	i64 8601935802264776013, ; 134: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 79
	i64 8626175481042262068, ; 135: Java.Interop => 0x77b654e585b55834 => 5
	i64 8639588376636138208, ; 136: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 68
	i64 8684531736582871431, ; 137: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 126
	i64 8844506025403580595, ; 138: Plugin.FirebasePushNotification => 0x7abdff5eb1fb80b3 => 12
	i64 8853378295825400934, ; 139: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 115
	i64 8951477988056063522, ; 140: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0x7c3a09cd9ccf5e22 => 72
	i64 9312692141327339315, ; 141: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 84
	i64 9324707631942237306, ; 142: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 34
	i64 9662334977499516867, ; 143: System.Numerics.dll => 0x8617827802b0cfc3 => 21
	i64 9678050649315576968, ; 144: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 44
	i64 9704315356731487263, ; 145: Plugin.FirebasePushNotification.dll => 0x86aca766ba59341f => 12
	i64 9711637524876806384, ; 146: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 65
	i64 9735414641753518179, ; 147: Xamarin.Firebase.Encoders.Proto => 0x871b240946daf063 => 92
	i64 9774216967140627647, ; 148: Xamarin.Firebase.Datatransport.dll => 0x87a4fe8bac0354bf => 89
	i64 9796610708422913120, ; 149: Xamarin.Firebase.Iid.Interop => 0x87f48d88de55ec60 => 93
	i64 9808709177481450983, ; 150: Mono.Android.dll => 0x881f890734e555e7 => 8
	i64 9825649861376906464, ; 151: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 41
	i64 9834056768316610435, ; 152: System.Transactions.dll => 0x8879968718899783 => 122
	i64 9875200773399460291, ; 153: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 108
	i64 9998632235833408227, ; 154: Mono.Security => 0x8ac2470b209ebae3 => 132
	i64 10038780035334861115, ; 155: System.Net.Http.dll => 0x8b50e941206af13b => 19
	i64 10226222362177979215, ; 156: Xamarin.Kotlin.StdLib.Jdk7 => 0x8dead70ebbc6434f => 117
	i64 10229024438826829339, ; 157: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 48
	i64 10321854143672141184, ; 158: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 114
	i64 10352330178246763130, ; 159: Xamarin.Firebase.Measurement.Connector => 0x8faadd72b7f4627a => 96
	i64 10376576884623852283, ; 160: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 78
	i64 10406448008575299332, ; 161: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 120
	i64 10430153318873392755, ; 162: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 46
	i64 10447083246144586668, ; 163: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 6
	i64 10847732767863316357, ; 164: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 35
	i64 11019817191295005410, ; 165: Xamarin.AndroidX.Annotation.Jvm.dll => 0x98ee415998e1b2e2 => 32
	i64 11023048688141570732, ; 166: System.Core => 0x98f9bc61168392ac => 16
	i64 11037814507248023548, ; 167: System.Xml => 0x992e31d0412bf7fc => 27
	i64 11071824625609515081, ; 168: Xamarin.Google.ErrorProne.Annotations => 0x99a705d600e0a049 => 106
	i64 11162124722117608902, ; 169: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 83
	i64 11171845786728836392, ; 170: Xamarin.GooglePlayServices.CloudMessaging.dll => 0x9b0a5e8d536aad28 => 110
	i64 11336891506707244397, ; 171: Xamarin.Firebase.Datatransport => 0x9d54bac28a6da56d => 89
	i64 11340910727871153756, ; 172: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 47
	i64 11360823163839134928, ; 173: App2.Android => 0x9da9c079aca93cd0 => 0
	i64 11376351552967644903, ; 174: Xamarin.Firebase.Annotations.dll => 0x9de0eb76829996e7 => 86
	i64 11392833485892708388, ; 175: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 71
	i64 11529969570048099689, ; 176: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 83
	i64 11578238080964724296, ; 177: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 56
	i64 11580057168383206117, ; 178: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 30
	i64 11591352189662810718, ; 179: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0xa0dcc167234c525e => 76
	i64 11597940890313164233, ; 180: netstandard => 0xa0f429ca8d1805c9 => 1
	i64 11672361001936329215, ; 181: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 53
	i64 12102847907131387746, ; 182: System.Buffers => 0xa7f5f40c43256f62 => 15
	i64 12137774235383566651, ; 183: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 81
	i64 12145679461940342714, ; 184: System.Text.Json => 0xa88e1f1ebcb62fba => 26
	i64 12346958216201575315, ; 185: Xamarin.JavaX.Inject.dll => 0xab593514a5491b93 => 113
	i64 12451044538927396471, ; 186: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 52
	i64 12466513435562512481, ; 187: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 63
	i64 12487638416075308985, ; 188: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 49
	i64 12538491095302438457, ; 189: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 39
	i64 12550732019250633519, ; 190: System.IO.Compression => 0xae2d28465e8e1b2f => 125
	i64 12700543734426720211, ; 191: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 40
	i64 12828192437253469131, ; 192: Xamarin.Kotlin.StdLib.Jdk8.dll => 0xb206e50e14d873cb => 118
	i64 12854524964145442905, ; 193: Xamarin.Firebase.Encoders.dll => 0xb26472594447b059 => 90
	i64 12963446364377008305, ; 194: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 124
	i64 13196197655982686080, ; 195: Prism => 0xb7224fda06b0bf80 => 14
	i64 13370592475155966277, ; 196: System.Runtime.Serialization => 0xb98de304062ea945 => 2
	i64 13401370062847626945, ; 197: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 81
	i64 13404347523447273790, ; 198: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 42
	i64 13454009404024712428, ; 199: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 107
	i64 13465488254036897740, ; 200: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 116
	i64 13491513212026656886, ; 201: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 36
	i64 13572454107664307259, ; 202: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 73
	i64 13647894001087880694, ; 203: System.Data.dll => 0xbd670f48cb071df6 => 121
	i64 13828521679616088467, ; 204: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 115
	i64 13829530607229561650, ; 205: Xamarin.Firebase.Installations.InterOp => 0xbfec5cd0b64f6b32 => 95
	i64 13959074834287824816, ; 206: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 52
	i64 13967638549803255703, ; 207: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 99
	i64 14124974489674258913, ; 208: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 39
	i64 14172845254133543601, ; 209: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 66
	i64 14261073672896646636, ; 210: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 71
	i64 14486659737292545672, ; 211: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 59
	i64 14524915121004231475, ; 212: Xamarin.JavaX.Inject => 0xc992dd58a4283b33 => 113
	i64 14551742072151931844, ; 213: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 25
	i64 14644440854989303794, ; 214: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 64
	i64 14789919016435397935, ; 215: Xamarin.Firebase.Common.dll => 0xcd4058fc2f6d352f => 87
	i64 14792063746108907174, ; 216: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 107
	i64 14809388726477333247, ; 217: Xamarin.GooglePlayServices.Stats.dll => 0xcd8584954e5b22ff => 111
	i64 14852515768018889994, ; 218: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 47
	i64 14958496593779620648, ; 219: App2 => 0xcf974166061ffb28 => 3
	i64 14987728460634540364, ; 220: System.IO.Compression.dll => 0xcfff1ba06622494c => 125
	i64 14988210264188246988, ; 221: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 49
	i64 15024878362326791334, ; 222: System.Net.Http.Json => 0xd0831743ebf0f4a6 => 20
	i64 15150743910298169673, ; 223: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xd2424150783c3149 => 72
	i64 15279429628684179188, ; 224: Xamarin.KotlinX.Coroutines.Android.dll => 0xd40b704b1c4c96f4 => 119
	i64 15370334346939861994, ; 225: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 46
	i64 15582737692548360875, ; 226: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 62
	i64 15609085926864131306, ; 227: System.dll => 0xd89e9cf3334914ea => 17
	i64 15644590034465900806, ; 228: Microsoft.Toolkit.Mvvm.dll => 0xd91cbfbf6cf4c906 => 7
	i64 15777549416145007739, ; 229: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 75
	i64 15810740023422282496, ; 230: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 101
	i64 15930129725311349754, ; 231: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 112
	i64 15963349826457351533, ; 232: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 133
	i64 16035518054986892682, ; 233: Prism.dll => 0xde899ab610db458a => 14
	i64 16154507427712707110, ; 234: System => 0xe03056ea4e39aa26 => 17
	i64 16381405407414385978, ; 235: Plugin.Settings => 0xe356716cf698fd3a => 13
	i64 16423015068819898779, ; 236: Xamarin.Kotlin.StdLib.Jdk8 => 0xe3ea453135e5c19b => 118
	i64 16467346005009053642, ; 237: Xamarin.Google.Android.DataTransport.TransportApi => 0xe487c3f19e0337ca => 102
	i64 16565028646146589191, ; 238: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 127
	i64 16621146507174665210, ; 239: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 43
	i64 16677317093839702854, ; 240: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 69
	i64 16822611501064131242, ; 241: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 123
	i64 16833383113903931215, ; 242: mscorlib => 0xe99c30c1484d7f4f => 9
	i64 16973888863008331153, ; 243: Plugin.Settings.dll => 0xeb8f5dfd48921591 => 13
	i64 17024911836938395553, ; 244: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 31
	i64 17031351772568316411, ; 245: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 67
	i64 17037200463775726619, ; 246: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 55
	i64 17187273293601214786, ; 247: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 130
	i64 17229931436468516663, ; 248: App2.dll => 0xef1d035a770ab737 => 3
	i64 17434242208926550937, ; 249: Xamarin.Google.Android.DataTransport.TransportRuntime => 0xf1f2deeb1f304b99 => 104
	i64 17544493274320527064, ; 250: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 37
	i64 17677828421478984182, ; 251: Xamarin.Firebase.Installations.InterOp.dll => 0xf5544349c68f29f6 => 95
	i64 17704177640604968747, ; 252: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 63
	i64 17710060891934109755, ; 253: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 61
	i64 17838668724098252521, ; 254: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 15
	i64 17882897186074144999, ; 255: FormsViewGroup => 0xf82cd03e3ac830e7 => 4
	i64 17891337867145587222, ; 256: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 114
	i64 17892495832318972303, ; 257: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 101
	i64 17928294245072900555, ; 258: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 126
	i64 17945795017270165205, ; 259: Xamarin.Google.Android.DataTransport.TransportApi.dll => 0xf90c457cc05cfed5 => 102
	i64 17986907704309214542, ; 260: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 109
	i64 18116111925905154859, ; 261: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 36
	i64 18121036031235206392, ; 262: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 67
	i64 18129453464017766560, ; 263: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 129
	i64 18305135509493619199, ; 264: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 68
	i64 18337470502355292274, ; 265: Xamarin.Firebase.Messaging => 0xfe7bc8440c175072 => 97
	i64 18354825640458385537, ; 266: App2.Android.dll => 0xfeb970ac05c0f881 => 0
	i64 18380184030268848184 ; 267: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 82
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [268 x i32] [
	i32 51, i32 8, i32 40, i32 74, i32 75, i32 45, i32 60, i32 108, ; 0..7
	i32 124, i32 54, i32 50, i32 122, i32 100, i32 132, i32 105, i32 35, ; 8..15
	i32 2, i32 88, i32 33, i32 62, i32 55, i32 11, i32 18, i32 34, ; 16..23
	i32 74, i32 103, i32 6, i32 30, i32 61, i32 133, i32 117, i32 11, ; 24..31
	i32 66, i32 38, i32 50, i32 128, i32 131, i32 58, i32 25, i32 23, ; 32..39
	i32 44, i32 80, i32 24, i32 29, i32 27, i32 9, i32 10, i32 70, ; 40..47
	i32 23, i32 76, i32 98, i32 105, i32 90, i32 57, i32 31, i32 22, ; 48..55
	i32 120, i32 87, i32 109, i32 78, i32 77, i32 21, i32 24, i32 1, ; 56..63
	i32 73, i32 51, i32 18, i32 45, i32 91, i32 112, i32 7, i32 103, ; 64..71
	i32 10, i32 129, i32 82, i32 88, i32 130, i32 37, i32 29, i32 77, ; 72..79
	i32 99, i32 85, i32 64, i32 65, i32 80, i32 79, i32 43, i32 16, ; 80..87
	i32 32, i32 84, i32 41, i32 70, i32 59, i32 100, i32 4, i32 96, ; 88..95
	i32 26, i32 60, i32 58, i32 38, i32 48, i32 111, i32 106, i32 128, ; 96..103
	i32 54, i32 28, i32 104, i32 22, i32 86, i32 92, i32 56, i32 53, ; 104..111
	i32 93, i32 91, i32 28, i32 98, i32 85, i32 19, i32 116, i32 121, ; 112..119
	i32 33, i32 94, i32 110, i32 94, i32 127, i32 57, i32 20, i32 123, ; 120..127
	i32 5, i32 119, i32 131, i32 42, i32 69, i32 97, i32 79, i32 5, ; 128..135
	i32 68, i32 126, i32 12, i32 115, i32 72, i32 84, i32 34, i32 21, ; 136..143
	i32 44, i32 12, i32 65, i32 92, i32 89, i32 93, i32 8, i32 41, ; 144..151
	i32 122, i32 108, i32 132, i32 19, i32 117, i32 48, i32 114, i32 96, ; 152..159
	i32 78, i32 120, i32 46, i32 6, i32 35, i32 32, i32 16, i32 27, ; 160..167
	i32 106, i32 83, i32 110, i32 89, i32 47, i32 0, i32 86, i32 71, ; 168..175
	i32 83, i32 56, i32 30, i32 76, i32 1, i32 53, i32 15, i32 81, ; 176..183
	i32 26, i32 113, i32 52, i32 63, i32 49, i32 39, i32 125, i32 40, ; 184..191
	i32 118, i32 90, i32 124, i32 14, i32 2, i32 81, i32 42, i32 107, ; 192..199
	i32 116, i32 36, i32 73, i32 121, i32 115, i32 95, i32 52, i32 99, ; 200..207
	i32 39, i32 66, i32 71, i32 59, i32 113, i32 25, i32 64, i32 87, ; 208..215
	i32 107, i32 111, i32 47, i32 3, i32 125, i32 49, i32 20, i32 72, ; 216..223
	i32 119, i32 46, i32 62, i32 17, i32 7, i32 75, i32 101, i32 112, ; 224..231
	i32 133, i32 14, i32 17, i32 13, i32 118, i32 102, i32 127, i32 43, ; 232..239
	i32 69, i32 123, i32 9, i32 13, i32 31, i32 67, i32 55, i32 130, ; 240..247
	i32 3, i32 104, i32 37, i32 95, i32 63, i32 61, i32 15, i32 4, ; 248..255
	i32 114, i32 101, i32 126, i32 102, i32 109, i32 36, i32 67, i32 129, ; 256..263
	i32 68, i32 97, i32 0, i32 82 ; 264..267
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
