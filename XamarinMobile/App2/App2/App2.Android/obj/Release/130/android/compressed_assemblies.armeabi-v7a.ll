; ModuleID = 'obj\Release\130\android\compressed_assemblies.armeabi-v7a.ll'
source_filename = "obj\Release\130\android\compressed_assemblies.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.CompressedAssemblyDescriptor = type {
	i32,; uint32_t uncompressed_file_size
	i8,; bool loaded
	i8*; uint8_t* data
}

%struct.CompressedAssemblies = type {
	i32,; uint32_t count
	%struct.CompressedAssemblyDescriptor*; CompressedAssemblyDescriptor* descriptors
}
@__CompressedAssemblyDescriptor_data_0 = internal global [457728 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_1 = internal global [691712 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_2 = internal global [16384 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_3 = internal global [168960 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_4 = internal global [8704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_5 = internal global [67072 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_6 = internal global [2619904 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_7 = internal global [121856 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_8 = internal global [19968 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_9 = internal global [690176 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_10 = internal global [51200 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_11 = internal global [17408 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_12 = internal global [82432 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_13 = internal global [14736 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_14 = internal global [17920 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_15 = internal global [391168 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_16 = internal global [748032 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_17 = internal global [26112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_18 = internal global [54272 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_19 = internal global [222208 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_20 = internal global [38912 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_21 = internal global [8192 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_22 = internal global [419328 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_23 = internal global [55808 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_24 = internal global [68096 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_25 = internal global [579584 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_26 = internal global [15248 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_27 = internal global [65024 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_28 = internal global [1397760 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_29 = internal global [878080 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_30 = internal global [67072 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_31 = internal global [16896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_32 = internal global [463360 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_33 = internal global [30720 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_34 = internal global [17920 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_35 = internal global [79360 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_36 = internal global [824832 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_37 = internal global [9728 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_38 = internal global [44032 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_39 = internal global [205312 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_40 = internal global [15872 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_41 = internal global [16896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_42 = internal global [16896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_43 = internal global [29184 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_44 = internal global [37376 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_45 = internal global [424448 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_46 = internal global [14336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_47 = internal global [40448 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_48 = internal global [10240 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_49 = internal global [58368 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_50 = internal global [30720 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_51 = internal global [8704 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_52 = internal global [10240 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_53 = internal global [47616 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_54 = internal global [1207296 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_55 = internal global [934912 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_56 = internal global [263040 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_57 = internal global [103424 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_58 = internal global [29696 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_59 = internal global [97792 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_60 = internal global [391168 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_61 = internal global [258048 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_62 = internal global [76800 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_63 = internal global [23480 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_64 = internal global [13312 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_65 = internal global [50176 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_66 = internal global [18432 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_67 = internal global [153024 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_68 = internal global [15296 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_69 = internal global [15296 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_70 = internal global [15296 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_71 = internal global [2229680 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_72 = internal global [26560 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_73 = internal global [537008 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_74 = internal global [2182144 x i8] zeroinitializer, align 1


; Compressed assembly data storage
@compressed_assembly_descriptors = internal global [75 x %struct.CompressedAssemblyDescriptor] [
	; 0
	%struct.CompressedAssemblyDescriptor {
		i32 457728, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([457728 x i8], [457728 x i8]* @__CompressedAssemblyDescriptor_data_0, i32 0, i32 0); data
	}, 
	; 1
	%struct.CompressedAssemblyDescriptor {
		i32 691712, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([691712 x i8], [691712 x i8]* @__CompressedAssemblyDescriptor_data_1, i32 0, i32 0); data
	}, 
	; 2
	%struct.CompressedAssemblyDescriptor {
		i32 16384, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16384 x i8], [16384 x i8]* @__CompressedAssemblyDescriptor_data_2, i32 0, i32 0); data
	}, 
	; 3
	%struct.CompressedAssemblyDescriptor {
		i32 168960, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([168960 x i8], [168960 x i8]* @__CompressedAssemblyDescriptor_data_3, i32 0, i32 0); data
	}, 
	; 4
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([8704 x i8], [8704 x i8]* @__CompressedAssemblyDescriptor_data_4, i32 0, i32 0); data
	}, 
	; 5
	%struct.CompressedAssemblyDescriptor {
		i32 67072, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([67072 x i8], [67072 x i8]* @__CompressedAssemblyDescriptor_data_5, i32 0, i32 0); data
	}, 
	; 6
	%struct.CompressedAssemblyDescriptor {
		i32 2619904, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2619904 x i8], [2619904 x i8]* @__CompressedAssemblyDescriptor_data_6, i32 0, i32 0); data
	}, 
	; 7
	%struct.CompressedAssemblyDescriptor {
		i32 121856, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([121856 x i8], [121856 x i8]* @__CompressedAssemblyDescriptor_data_7, i32 0, i32 0); data
	}, 
	; 8
	%struct.CompressedAssemblyDescriptor {
		i32 19968, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([19968 x i8], [19968 x i8]* @__CompressedAssemblyDescriptor_data_8, i32 0, i32 0); data
	}, 
	; 9
	%struct.CompressedAssemblyDescriptor {
		i32 690176, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([690176 x i8], [690176 x i8]* @__CompressedAssemblyDescriptor_data_9, i32 0, i32 0); data
	}, 
	; 10
	%struct.CompressedAssemblyDescriptor {
		i32 51200, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([51200 x i8], [51200 x i8]* @__CompressedAssemblyDescriptor_data_10, i32 0, i32 0); data
	}, 
	; 11
	%struct.CompressedAssemblyDescriptor {
		i32 17408, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([17408 x i8], [17408 x i8]* @__CompressedAssemblyDescriptor_data_11, i32 0, i32 0); data
	}, 
	; 12
	%struct.CompressedAssemblyDescriptor {
		i32 82432, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([82432 x i8], [82432 x i8]* @__CompressedAssemblyDescriptor_data_12, i32 0, i32 0); data
	}, 
	; 13
	%struct.CompressedAssemblyDescriptor {
		i32 14736, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14736 x i8], [14736 x i8]* @__CompressedAssemblyDescriptor_data_13, i32 0, i32 0); data
	}, 
	; 14
	%struct.CompressedAssemblyDescriptor {
		i32 17920, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([17920 x i8], [17920 x i8]* @__CompressedAssemblyDescriptor_data_14, i32 0, i32 0); data
	}, 
	; 15
	%struct.CompressedAssemblyDescriptor {
		i32 391168, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([391168 x i8], [391168 x i8]* @__CompressedAssemblyDescriptor_data_15, i32 0, i32 0); data
	}, 
	; 16
	%struct.CompressedAssemblyDescriptor {
		i32 748032, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([748032 x i8], [748032 x i8]* @__CompressedAssemblyDescriptor_data_16, i32 0, i32 0); data
	}, 
	; 17
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26112 x i8], [26112 x i8]* @__CompressedAssemblyDescriptor_data_17, i32 0, i32 0); data
	}, 
	; 18
	%struct.CompressedAssemblyDescriptor {
		i32 54272, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([54272 x i8], [54272 x i8]* @__CompressedAssemblyDescriptor_data_18, i32 0, i32 0); data
	}, 
	; 19
	%struct.CompressedAssemblyDescriptor {
		i32 222208, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([222208 x i8], [222208 x i8]* @__CompressedAssemblyDescriptor_data_19, i32 0, i32 0); data
	}, 
	; 20
	%struct.CompressedAssemblyDescriptor {
		i32 38912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([38912 x i8], [38912 x i8]* @__CompressedAssemblyDescriptor_data_20, i32 0, i32 0); data
	}, 
	; 21
	%struct.CompressedAssemblyDescriptor {
		i32 8192, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([8192 x i8], [8192 x i8]* @__CompressedAssemblyDescriptor_data_21, i32 0, i32 0); data
	}, 
	; 22
	%struct.CompressedAssemblyDescriptor {
		i32 419328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([419328 x i8], [419328 x i8]* @__CompressedAssemblyDescriptor_data_22, i32 0, i32 0); data
	}, 
	; 23
	%struct.CompressedAssemblyDescriptor {
		i32 55808, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([55808 x i8], [55808 x i8]* @__CompressedAssemblyDescriptor_data_23, i32 0, i32 0); data
	}, 
	; 24
	%struct.CompressedAssemblyDescriptor {
		i32 68096, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([68096 x i8], [68096 x i8]* @__CompressedAssemblyDescriptor_data_24, i32 0, i32 0); data
	}, 
	; 25
	%struct.CompressedAssemblyDescriptor {
		i32 579584, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([579584 x i8], [579584 x i8]* @__CompressedAssemblyDescriptor_data_25, i32 0, i32 0); data
	}, 
	; 26
	%struct.CompressedAssemblyDescriptor {
		i32 15248, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15248 x i8], [15248 x i8]* @__CompressedAssemblyDescriptor_data_26, i32 0, i32 0); data
	}, 
	; 27
	%struct.CompressedAssemblyDescriptor {
		i32 65024, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([65024 x i8], [65024 x i8]* @__CompressedAssemblyDescriptor_data_27, i32 0, i32 0); data
	}, 
	; 28
	%struct.CompressedAssemblyDescriptor {
		i32 1397760, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1397760 x i8], [1397760 x i8]* @__CompressedAssemblyDescriptor_data_28, i32 0, i32 0); data
	}, 
	; 29
	%struct.CompressedAssemblyDescriptor {
		i32 878080, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([878080 x i8], [878080 x i8]* @__CompressedAssemblyDescriptor_data_29, i32 0, i32 0); data
	}, 
	; 30
	%struct.CompressedAssemblyDescriptor {
		i32 67072, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([67072 x i8], [67072 x i8]* @__CompressedAssemblyDescriptor_data_30, i32 0, i32 0); data
	}, 
	; 31
	%struct.CompressedAssemblyDescriptor {
		i32 16896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16896 x i8], [16896 x i8]* @__CompressedAssemblyDescriptor_data_31, i32 0, i32 0); data
	}, 
	; 32
	%struct.CompressedAssemblyDescriptor {
		i32 463360, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([463360 x i8], [463360 x i8]* @__CompressedAssemblyDescriptor_data_32, i32 0, i32 0); data
	}, 
	; 33
	%struct.CompressedAssemblyDescriptor {
		i32 30720, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30720 x i8], [30720 x i8]* @__CompressedAssemblyDescriptor_data_33, i32 0, i32 0); data
	}, 
	; 34
	%struct.CompressedAssemblyDescriptor {
		i32 17920, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([17920 x i8], [17920 x i8]* @__CompressedAssemblyDescriptor_data_34, i32 0, i32 0); data
	}, 
	; 35
	%struct.CompressedAssemblyDescriptor {
		i32 79360, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([79360 x i8], [79360 x i8]* @__CompressedAssemblyDescriptor_data_35, i32 0, i32 0); data
	}, 
	; 36
	%struct.CompressedAssemblyDescriptor {
		i32 824832, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([824832 x i8], [824832 x i8]* @__CompressedAssemblyDescriptor_data_36, i32 0, i32 0); data
	}, 
	; 37
	%struct.CompressedAssemblyDescriptor {
		i32 9728, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([9728 x i8], [9728 x i8]* @__CompressedAssemblyDescriptor_data_37, i32 0, i32 0); data
	}, 
	; 38
	%struct.CompressedAssemblyDescriptor {
		i32 44032, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([44032 x i8], [44032 x i8]* @__CompressedAssemblyDescriptor_data_38, i32 0, i32 0); data
	}, 
	; 39
	%struct.CompressedAssemblyDescriptor {
		i32 205312, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([205312 x i8], [205312 x i8]* @__CompressedAssemblyDescriptor_data_39, i32 0, i32 0); data
	}, 
	; 40
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15872 x i8], [15872 x i8]* @__CompressedAssemblyDescriptor_data_40, i32 0, i32 0); data
	}, 
	; 41
	%struct.CompressedAssemblyDescriptor {
		i32 16896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16896 x i8], [16896 x i8]* @__CompressedAssemblyDescriptor_data_41, i32 0, i32 0); data
	}, 
	; 42
	%struct.CompressedAssemblyDescriptor {
		i32 16896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([16896 x i8], [16896 x i8]* @__CompressedAssemblyDescriptor_data_42, i32 0, i32 0); data
	}, 
	; 43
	%struct.CompressedAssemblyDescriptor {
		i32 29184, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([29184 x i8], [29184 x i8]* @__CompressedAssemblyDescriptor_data_43, i32 0, i32 0); data
	}, 
	; 44
	%struct.CompressedAssemblyDescriptor {
		i32 37376, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([37376 x i8], [37376 x i8]* @__CompressedAssemblyDescriptor_data_44, i32 0, i32 0); data
	}, 
	; 45
	%struct.CompressedAssemblyDescriptor {
		i32 424448, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([424448 x i8], [424448 x i8]* @__CompressedAssemblyDescriptor_data_45, i32 0, i32 0); data
	}, 
	; 46
	%struct.CompressedAssemblyDescriptor {
		i32 14336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14336 x i8], [14336 x i8]* @__CompressedAssemblyDescriptor_data_46, i32 0, i32 0); data
	}, 
	; 47
	%struct.CompressedAssemblyDescriptor {
		i32 40448, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([40448 x i8], [40448 x i8]* @__CompressedAssemblyDescriptor_data_47, i32 0, i32 0); data
	}, 
	; 48
	%struct.CompressedAssemblyDescriptor {
		i32 10240, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([10240 x i8], [10240 x i8]* @__CompressedAssemblyDescriptor_data_48, i32 0, i32 0); data
	}, 
	; 49
	%struct.CompressedAssemblyDescriptor {
		i32 58368, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([58368 x i8], [58368 x i8]* @__CompressedAssemblyDescriptor_data_49, i32 0, i32 0); data
	}, 
	; 50
	%struct.CompressedAssemblyDescriptor {
		i32 30720, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30720 x i8], [30720 x i8]* @__CompressedAssemblyDescriptor_data_50, i32 0, i32 0); data
	}, 
	; 51
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([8704 x i8], [8704 x i8]* @__CompressedAssemblyDescriptor_data_51, i32 0, i32 0); data
	}, 
	; 52
	%struct.CompressedAssemblyDescriptor {
		i32 10240, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([10240 x i8], [10240 x i8]* @__CompressedAssemblyDescriptor_data_52, i32 0, i32 0); data
	}, 
	; 53
	%struct.CompressedAssemblyDescriptor {
		i32 47616, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([47616 x i8], [47616 x i8]* @__CompressedAssemblyDescriptor_data_53, i32 0, i32 0); data
	}, 
	; 54
	%struct.CompressedAssemblyDescriptor {
		i32 1207296, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1207296 x i8], [1207296 x i8]* @__CompressedAssemblyDescriptor_data_54, i32 0, i32 0); data
	}, 
	; 55
	%struct.CompressedAssemblyDescriptor {
		i32 934912, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([934912 x i8], [934912 x i8]* @__CompressedAssemblyDescriptor_data_55, i32 0, i32 0); data
	}, 
	; 56
	%struct.CompressedAssemblyDescriptor {
		i32 263040, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([263040 x i8], [263040 x i8]* @__CompressedAssemblyDescriptor_data_56, i32 0, i32 0); data
	}, 
	; 57
	%struct.CompressedAssemblyDescriptor {
		i32 103424, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([103424 x i8], [103424 x i8]* @__CompressedAssemblyDescriptor_data_57, i32 0, i32 0); data
	}, 
	; 58
	%struct.CompressedAssemblyDescriptor {
		i32 29696, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([29696 x i8], [29696 x i8]* @__CompressedAssemblyDescriptor_data_58, i32 0, i32 0); data
	}, 
	; 59
	%struct.CompressedAssemblyDescriptor {
		i32 97792, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([97792 x i8], [97792 x i8]* @__CompressedAssemblyDescriptor_data_59, i32 0, i32 0); data
	}, 
	; 60
	%struct.CompressedAssemblyDescriptor {
		i32 391168, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([391168 x i8], [391168 x i8]* @__CompressedAssemblyDescriptor_data_60, i32 0, i32 0); data
	}, 
	; 61
	%struct.CompressedAssemblyDescriptor {
		i32 258048, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([258048 x i8], [258048 x i8]* @__CompressedAssemblyDescriptor_data_61, i32 0, i32 0); data
	}, 
	; 62
	%struct.CompressedAssemblyDescriptor {
		i32 76800, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([76800 x i8], [76800 x i8]* @__CompressedAssemblyDescriptor_data_62, i32 0, i32 0); data
	}, 
	; 63
	%struct.CompressedAssemblyDescriptor {
		i32 23480, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([23480 x i8], [23480 x i8]* @__CompressedAssemblyDescriptor_data_63, i32 0, i32 0); data
	}, 
	; 64
	%struct.CompressedAssemblyDescriptor {
		i32 13312, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([13312 x i8], [13312 x i8]* @__CompressedAssemblyDescriptor_data_64, i32 0, i32 0); data
	}, 
	; 65
	%struct.CompressedAssemblyDescriptor {
		i32 50176, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([50176 x i8], [50176 x i8]* @__CompressedAssemblyDescriptor_data_65, i32 0, i32 0); data
	}, 
	; 66
	%struct.CompressedAssemblyDescriptor {
		i32 18432, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([18432 x i8], [18432 x i8]* @__CompressedAssemblyDescriptor_data_66, i32 0, i32 0); data
	}, 
	; 67
	%struct.CompressedAssemblyDescriptor {
		i32 153024, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([153024 x i8], [153024 x i8]* @__CompressedAssemblyDescriptor_data_67, i32 0, i32 0); data
	}, 
	; 68
	%struct.CompressedAssemblyDescriptor {
		i32 15296, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15296 x i8], [15296 x i8]* @__CompressedAssemblyDescriptor_data_68, i32 0, i32 0); data
	}, 
	; 69
	%struct.CompressedAssemblyDescriptor {
		i32 15296, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15296 x i8], [15296 x i8]* @__CompressedAssemblyDescriptor_data_69, i32 0, i32 0); data
	}, 
	; 70
	%struct.CompressedAssemblyDescriptor {
		i32 15296, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([15296 x i8], [15296 x i8]* @__CompressedAssemblyDescriptor_data_70, i32 0, i32 0); data
	}, 
	; 71
	%struct.CompressedAssemblyDescriptor {
		i32 2229680, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2229680 x i8], [2229680 x i8]* @__CompressedAssemblyDescriptor_data_71, i32 0, i32 0); data
	}, 
	; 72
	%struct.CompressedAssemblyDescriptor {
		i32 26560, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([26560 x i8], [26560 x i8]* @__CompressedAssemblyDescriptor_data_72, i32 0, i32 0); data
	}, 
	; 73
	%struct.CompressedAssemblyDescriptor {
		i32 537008, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([537008 x i8], [537008 x i8]* @__CompressedAssemblyDescriptor_data_73, i32 0, i32 0); data
	}, 
	; 74
	%struct.CompressedAssemblyDescriptor {
		i32 2182144, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2182144 x i8], [2182144 x i8]* @__CompressedAssemblyDescriptor_data_74, i32 0, i32 0); data
	}
], align 4; end of 'compressed_assembly_descriptors' array


; compressed_assemblies
@compressed_assemblies = local_unnamed_addr global %struct.CompressedAssemblies {
	i32 75, ; count
	%struct.CompressedAssemblyDescriptor* getelementptr inbounds ([75 x %struct.CompressedAssemblyDescriptor], [75 x %struct.CompressedAssemblyDescriptor]* @compressed_assembly_descriptors, i32 0, i32 0); descriptors
}, align 4


!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a200af12c1e846626b8caebd926ac14c185f71ec"}
