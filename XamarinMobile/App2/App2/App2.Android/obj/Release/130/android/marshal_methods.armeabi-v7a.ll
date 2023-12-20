; ModuleID = 'obj\Release\130\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Release\130\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [150 x i32] [
	i32 34715100, ; 0: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 58
	i32 39109920, ; 1: Newtonsoft.Json.dll => 0x254c520 => 10
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 49
	i32 134690465, ; 3: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 65
	i32 182336117, ; 4: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 42
	i32 209399409, ; 5: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 28
	i32 318968648, ; 6: Xamarin.AndroidX.Activity.dll => 0x13031348 => 25
	i32 321597661, ; 7: System.Numerics => 0x132b30dd => 19
	i32 342366114, ; 8: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 36
	i32 442521989, ; 9: Xamarin.Essentials => 0x1a605985 => 45
	i32 450948140, ; 10: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 34
	i32 465846621, ; 11: mscorlib => 0x1bc4415d => 8
	i32 469710990, ; 12: System.dll => 0x1bff388e => 16
	i32 485140951, ; 13: Xamarin.Google.Android.DataTransport.TransportRuntime => 0x1ceaa9d7 => 55
	i32 495452658, ; 14: Xamarin.Google.Android.DataTransport.TransportRuntime.dll => 0x1d8801f2 => 55
	i32 501000162, ; 15: Prism.dll => 0x1ddca7e2 => 13
	i32 507148113, ; 16: Xamarin.Google.Android.DataTransport.TransportApi.dll => 0x1e3a7751 => 53
	i32 527452488, ; 17: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 65
	i32 548916678, ; 18: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 5
	i32 627609679, ; 19: Xamarin.AndroidX.CustomView => 0x2568904f => 32
	i32 662205335, ; 20: System.Text.Encodings.Web.dll => 0x27787397 => 21
	i32 663517072, ; 21: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 43
	i32 690569205, ; 22: System.Xml.Linq.dll => 0x29293ff5 => 24
	i32 691348768, ; 23: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 67
	i32 700284507, ; 24: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 62
	i32 720511267, ; 25: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 66
	i32 809851609, ; 26: System.Drawing.Common.dll => 0x30455ad9 => 70
	i32 827507903, ; 27: App2.Android => 0x3152c4bf => 0
	i32 835661280, ; 28: MvvmHelpers.dll => 0x31cf2de0 => 9
	i32 869159342, ; 29: App2 => 0x33ce51ae => 2
	i32 878954865, ; 30: System.Net.Http.Json => 0x3463c971 => 18
	i32 913382283, ; 31: Plugin.Settings => 0x36711b8b => 12
	i32 928116545, ; 32: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 58
	i32 955402788, ; 33: Newtonsoft.Json => 0x38f24a24 => 10
	i32 956575887, ; 34: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 66
	i32 967690846, ; 35: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 36
	i32 974778368, ; 36: FormsViewGroup.dll => 0x3a19f000 => 3
	i32 996733531, ; 37: Xamarin.Google.Android.DataTransport.TransportBackendCct => 0x3b68f25b => 54
	i32 1012816738, ; 38: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 41
	i32 1031528504, ; 39: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 57
	i32 1035644815, ; 40: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 27
	i32 1042160112, ; 41: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 51
	i32 1052210849, ; 42: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 38
	i32 1084122840, ; 43: Xamarin.Kotlin.StdLib => 0x409e66d8 => 64
	i32 1098259244, ; 44: System => 0x41761b2c => 16
	i32 1231759121, ; 45: App2.dll => 0x496b2711 => 2
	i32 1275534314, ; 46: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 67
	i32 1293217323, ; 47: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 33
	i32 1309284514, ; 48: Plugin.FirebasePushNotification => 0x4e0a18a2 => 11
	i32 1365406463, ; 49: System.ServiceModel.Internals.dll => 0x516272ff => 71
	i32 1376866003, ; 50: Xamarin.AndroidX.SavedState => 0x52114ed3 => 41
	i32 1379897097, ; 51: Xamarin.JavaX.Inject => 0x523f8f09 => 61
	i32 1395363092, ; 52: Plugin.Settings.dll => 0x532b8d14 => 12
	i32 1406073936, ; 53: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 30
	i32 1411638395, ; 54: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 20
	i32 1460219004, ; 55: Xamarin.Forms.Xaml => 0x57092c7c => 52
	i32 1469204771, ; 56: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 26
	i32 1592978981, ; 57: System.Runtime.Serialization.dll => 0x5ef2ee25 => 1
	i32 1597949149, ; 58: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 57
	i32 1622152042, ; 59: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 39
	i32 1639515021, ; 60: System.Net.Http.dll => 0x61b9038d => 17
	i32 1658251792, ; 61: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 56
	i32 1698840827, ; 62: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 63
	i32 1729485958, ; 63: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 29
	i32 1766324549, ; 64: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 42
	i32 1776026572, ; 65: System.Core.dll => 0x69dc03cc => 15
	i32 1788241197, ; 66: Xamarin.AndroidX.Fragment => 0x6a96652d => 34
	i32 1796167890, ; 67: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 5
	i32 1808609942, ; 68: Xamarin.AndroidX.Loader => 0x6bcd3296 => 39
	i32 1813058853, ; 69: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 64
	i32 1813201214, ; 70: Xamarin.Google.Android.Material => 0x6c13413e => 56
	i32 1867746548, ; 71: Xamarin.Essentials.dll => 0x6f538cf4 => 45
	i32 1876173635, ; 72: Xamarin.Firebase.Encoders.Proto => 0x6fd42343 => 47
	i32 1878053835, ; 73: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 52
	i32 1908813208, ; 74: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 59
	i32 1933215285, ; 75: Xamarin.Firebase.Messaging.dll => 0x733a8635 => 48
	i32 1983156543, ; 76: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 63
	i32 2011961780, ; 77: System.Buffers.dll => 0x77ec19b4 => 14
	i32 2019465201, ; 78: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 38
	i32 2055257422, ; 79: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 37
	i32 2066202781, ; 80: Prism => 0x7b27c09d => 13
	i32 2097448633, ; 81: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 35
	i32 2124230737, ; 82: Xamarin.Google.Android.DataTransport.TransportBackendCct.dll => 0x7e9d3051 => 54
	i32 2126786730, ; 83: Xamarin.Forms.Platform.Android => 0x7ec430aa => 50
	i32 2201107256, ; 84: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 68
	i32 2201231467, ; 85: System.Net.Http => 0x8334206b => 17
	i32 2261553826, ; 86: App2.Android.dll => 0x86cc92a2 => 0
	i32 2279755925, ; 87: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 40
	i32 2435904999, ; 88: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 72
	i32 2475788418, ; 89: Java.Interop.dll => 0x93918882 => 4
	i32 2483742551, ; 90: Xamarin.Firebase.Messaging => 0x940ae757 => 48
	i32 2497152587, ; 91: Microsoft.Toolkit.Mvvm => 0x94d7864b => 6
	i32 2570120770, ; 92: System.Text.Encodings.Web => 0x9930ee42 => 21
	i32 2605712449, ; 93: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 68
	i32 2620111890, ; 94: Xamarin.Firebase.Encoders.dll => 0x9c2bbc12 => 46
	i32 2639764100, ; 95: Xamarin.Firebase.Encoders => 0x9d579a84 => 46
	i32 2732626843, ; 96: Xamarin.AndroidX.Activity => 0xa2e0939b => 25
	i32 2737747696, ; 97: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 26
	i32 2766581644, ; 98: Xamarin.Forms.Core => 0xa4e6af8c => 49
	i32 2770495804, ; 99: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 62
	i32 2778768386, ; 100: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 44
	i32 2810250172, ; 101: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 30
	i32 2819470561, ; 102: System.Xml.dll => 0xa80db4e1 => 23
	i32 2853208004, ; 103: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 44
	i32 2905242038, ; 104: mscorlib.dll => 0xad2a79b6 => 8
	i32 2978675010, ; 105: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 33
	i32 3044182254, ; 106: FormsViewGroup => 0xb57288ee => 3
	i32 3058099980, ; 107: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 60
	i32 3111772706, ; 108: System.Runtime.Serialization => 0xb979e222 => 1
	i32 3124832203, ; 109: System.Threading.Tasks.Extensions => 0xba4127cb => 74
	i32 3155362983, ; 110: Xamarin.Google.Android.DataTransport.TransportApi => 0xbc1304a7 => 53
	i32 3204380047, ; 111: System.Data.dll => 0xbefef58f => 69
	i32 3230466174, ; 112: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 59
	i32 3247949154, ; 113: Mono.Security => 0xc197c562 => 73
	i32 3257332390, ; 114: MvvmHelpers => 0xc226f2a6 => 9
	i32 3258312781, ; 115: Xamarin.AndroidX.CardView => 0xc235e84d => 29
	i32 3265893370, ; 116: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 74
	i32 3317135071, ; 117: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 32
	i32 3317144872, ; 118: System.Data => 0xc5b79d28 => 69
	i32 3353484488, ; 119: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 35
	i32 3358260929, ; 120: System.Text.Json => 0xc82afec1 => 22
	i32 3362522851, ; 121: Xamarin.AndroidX.Core => 0xc86c06e3 => 31
	i32 3366347497, ; 122: Java.Interop => 0xc8a662e9 => 4
	i32 3371992681, ; 123: Xamarin.Firebase.Encoders.Proto.dll => 0xc8fc8669 => 47
	i32 3374999561, ; 124: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 40
	i32 3395150330, ; 125: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 20
	i32 3401559547, ; 126: Plugin.FirebasePushNotification.dll => 0xcabfadfb => 11
	i32 3404865022, ; 127: System.ServiceModel.Internals => 0xcaf21dfe => 71
	i32 3429136800, ; 128: System.Xml => 0xcc6479a0 => 23
	i32 3476120550, ; 129: Mono.Android => 0xcf3163e6 => 7
	i32 3485117614, ; 130: System.Text.Json.dll => 0xcfbaacae => 22
	i32 3509114376, ; 131: System.Xml.Linq => 0xd128d608 => 24
	i32 3536029504, ; 132: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 50
	i32 3632359727, ; 133: Xamarin.Forms.Platform => 0xd881692f => 51
	i32 3641597786, ; 134: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 37
	i32 3645089577, ; 135: System.ComponentModel.DataAnnotations => 0xd943a729 => 72
	i32 3654326742, ; 136: Microsoft.Toolkit.Mvvm.dll => 0xd9d099d6 => 6
	i32 3672681054, ; 137: Mono.Android.dll => 0xdae8aa5e => 7
	i32 3682565725, ; 138: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 28
	i32 3689375977, ; 139: System.Drawing.Common => 0xdbe768e9 => 70
	i32 3737834244, ; 140: System.Net.Http.Json.dll => 0xdecad304 => 18
	i32 3829621856, ; 141: System.Numerics.dll => 0xe4436460 => 19
	i32 3896760992, ; 142: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 31
	i32 3921031405, ; 143: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 43
	i32 3934056515, ; 144: Xamarin.JavaX.Inject.dll => 0xea7cf043 => 61
	i32 3955647286, ; 145: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 27
	i32 3970018735, ; 146: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 60
	i32 4105002889, ; 147: Mono.Security.dll => 0xf4ad5f89 => 73
	i32 4151237749, ; 148: System.Core => 0xf76edc75 => 15
	i32 4260525087 ; 149: System.Buffers => 0xfdf2741f => 14
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [150 x i32] [
	i32 58, i32 10, i32 49, i32 65, i32 42, i32 28, i32 25, i32 19, ; 0..7
	i32 36, i32 45, i32 34, i32 8, i32 16, i32 55, i32 55, i32 13, ; 8..15
	i32 53, i32 65, i32 5, i32 32, i32 21, i32 43, i32 24, i32 67, ; 16..23
	i32 62, i32 66, i32 70, i32 0, i32 9, i32 2, i32 18, i32 12, ; 24..31
	i32 58, i32 10, i32 66, i32 36, i32 3, i32 54, i32 41, i32 57, ; 32..39
	i32 27, i32 51, i32 38, i32 64, i32 16, i32 2, i32 67, i32 33, ; 40..47
	i32 11, i32 71, i32 41, i32 61, i32 12, i32 30, i32 20, i32 52, ; 48..55
	i32 26, i32 1, i32 57, i32 39, i32 17, i32 56, i32 63, i32 29, ; 56..63
	i32 42, i32 15, i32 34, i32 5, i32 39, i32 64, i32 56, i32 45, ; 64..71
	i32 47, i32 52, i32 59, i32 48, i32 63, i32 14, i32 38, i32 37, ; 72..79
	i32 13, i32 35, i32 54, i32 50, i32 68, i32 17, i32 0, i32 40, ; 80..87
	i32 72, i32 4, i32 48, i32 6, i32 21, i32 68, i32 46, i32 46, ; 88..95
	i32 25, i32 26, i32 49, i32 62, i32 44, i32 30, i32 23, i32 44, ; 96..103
	i32 8, i32 33, i32 3, i32 60, i32 1, i32 74, i32 53, i32 69, ; 104..111
	i32 59, i32 73, i32 9, i32 29, i32 74, i32 32, i32 69, i32 35, ; 112..119
	i32 22, i32 31, i32 4, i32 47, i32 40, i32 20, i32 11, i32 71, ; 120..127
	i32 23, i32 7, i32 22, i32 24, i32 50, i32 51, i32 37, i32 72, ; 128..135
	i32 6, i32 7, i32 28, i32 70, i32 18, i32 19, i32 31, i32 43, ; 136..143
	i32 61, i32 27, i32 60, i32 73, i32 15, i32 14 ; 144..149
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a200af12c1e846626b8caebd926ac14c185f71ec"}
!llvm.linker.options = !{}
