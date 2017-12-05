// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "WavingFoliage"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Albedo("Albedo", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_WindBend("WindBend", Range( 0 , 2)) = 0
		_WindSpeed("WindSpeed", Range( 0 , 1)) = 0
		_WindTime("WindTime", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TreeTransparentCutout"  "Queue" = "Geometry+0" }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform float4 _Color;
		uniform float _WindTime;
		uniform float _WindSpeed;
		uniform float _WindBend;
		uniform float _Cutoff = 0.5;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float4 _waveSpeed = float4(1.2,2,1.6,4.8);
			float4 normalizeResult146_g1 = normalize( _waveSpeed );
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float4 temp_output_117_0_g1 = ( normalizeResult146_g1 * ( sin( ( ( ( float4(0.048,0.06,0.24,0.096) * ase_worldPos.x ) + ( ase_worldPos.z * float4(0.024,0.08,0.08,0.2) ) ) + ( ( ( ( ( 1.0 - ( _WindTime * 2.0 ) ) - v.color.b ) * _Time.y ) * _waveSpeed ) * ( _WindSpeed + v.color.g ) ) ) ) * ( v.texcoord.xy.y * _WindBend ) ) );
			float4 temp_output_155_0_g1 = ( temp_output_117_0_g1 * temp_output_117_0_g1 );
			float dotResult124_g1 = dot( temp_output_155_0_g1 , float4(0.024,0.04,-0.12,0.096) );
			float dotResult125_g1 = dot( temp_output_155_0_g1 , float4(0.006,0.02,-0.02,0.1) );
			float4 appendResult137_g1 = (float4(dotResult124_g1 , 0.0 , dotResult125_g1 , 0.0));
			v.vertex.xyz += appendResult137_g1.xyz;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 tex2DNode2 = tex2D( _Albedo, uv_Albedo );
			o.Albedo = ( tex2DNode2 * _Color ).rgb;
			o.Alpha = 1;
			clip( tex2DNode2.a - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13901
165;1033;1034;1004;1297.612;-118.9282;1.404865;True;True
Node;AmplifyShaderEditor.RangedFloatNode;9;-641.5405,697.7328;Float;False;Property;_WindSpeed;WindSpeed;3;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;4;-599.991,95.68031;Float;False;Property;_Color;Color;2;0;1,1,1,1;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;2;-728.7261,-134.4274;Float;True;Property;_Albedo;Albedo;0;0;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;11;-720.2128,546.0073;Float;False;Property;_WindTime;WindTime;3;0;0;0;1;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;10;-928.1326,1178.196;Float;False;Property;_WindBend;WindBend;3;0;0;0;2;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-280.0374,-19.51061;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.FunctionNode;8;-423.7863,367.5895;Float;False;SimpleWindFunction;-1;;1;23cea30200243164aa406ca0b0b44a34;3;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;1;FLOAT4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;WavingFoliage;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;0;False;0;0;Custom;0.5;True;True;0;True;TreeTransparentCutout;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;0;0;0;0;False;2;15;10;25;False;0.5;True;0;Zero;Zero;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;5;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;FLOAT;0.0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;2;0
WireConnection;5;1;4;0
WireConnection;8;0;9;0
WireConnection;8;1;10;0
WireConnection;8;2;11;0
WireConnection;0;0;5;0
WireConnection;0;10;2;4
WireConnection;0;11;8;0
ASEEND*/
//CHKSM=2F057B68FF91DA77204E9269F999FCA65665B0EF