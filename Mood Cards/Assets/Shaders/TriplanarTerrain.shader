// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.4249568,fgcg:0.9449887,fgcb:0.9632353,fgca:1,fgde:0.005,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:5475,x:32832,y:32961,varname:node_5475,prsc:2|diff-8470-OUT;n:type:ShaderForge.SFN_NormalVector,id:6260,x:31749,y:32338,prsc:2,pt:False;n:type:ShaderForge.SFN_Abs,id:4585,x:32167,y:32560,varname:node_4585,prsc:2|IN-6260-OUT;n:type:ShaderForge.SFN_Tex2d,id:6784,x:32296,y:32836,ptovrint:False,ptlb:node_6784,ptin:_node_6784,varname:node_6784,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d5ad9d5e7c34ffc4ca30e6528a1484c9,ntxv:0,isnm:False|UVIN-3034-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:5319,x:31767,y:32745,varname:node_5319,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:7492,x:31947,y:32745,varname:node_7492,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-5319-XYZ;n:type:ShaderForge.SFN_Multiply,id:3034,x:32110,y:32836,varname:node_3034,prsc:2|A-7492-OUT,B-7960-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7960,x:31899,y:32938,ptovrint:False,ptlb:Tiling,ptin:_Tiling,varname:node_7960,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_FragmentPosition,id:9967,x:31719,y:33032,varname:node_9967,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:2214,x:31884,y:33042,varname:node_2214,prsc:2,cc1:1,cc2:0,cc3:-1,cc4:-1|IN-9967-XYZ;n:type:ShaderForge.SFN_Multiply,id:384,x:32062,y:33123,varname:node_384,prsc:2|A-2214-OUT,B-7960-OUT;n:type:ShaderForge.SFN_Tex2d,id:8225,x:32248,y:33123,ptovrint:False,ptlb:node_6784_copy,ptin:_node_6784_copy,varname:_node_6784_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d5ad9d5e7c34ffc4ca30e6528a1484c9,ntxv:0,isnm:False|UVIN-384-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:986,x:31676,y:33318,varname:node_986,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:2070,x:31856,y:33318,varname:node_2070,prsc:2,cc1:1,cc2:2,cc3:-1,cc4:-1|IN-986-XYZ;n:type:ShaderForge.SFN_Multiply,id:3323,x:32019,y:33409,varname:node_3323,prsc:2|A-2070-OUT,B-7960-OUT;n:type:ShaderForge.SFN_Tex2d,id:1729,x:32205,y:33409,ptovrint:False,ptlb:node_6784_copy_copy,ptin:_node_6784_copy_copy,varname:_node_6784_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d5ad9d5e7c34ffc4ca30e6528a1484c9,ntxv:0,isnm:False|UVIN-3323-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9312,x:32421,y:32522,varname:node_9312,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-518-OUT;n:type:ShaderForge.SFN_Lerp,id:9795,x:32433,y:33025,varname:node_9795,prsc:2|A-6784-RGB,B-8225-RGB,T-9312-OUT;n:type:ShaderForge.SFN_Lerp,id:8470,x:32619,y:33142,varname:node_8470,prsc:2|A-9795-OUT,B-1729-RGB,T-8277-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8277,x:32445,y:32682,varname:node_8277,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-518-OUT;n:type:ShaderForge.SFN_Smoothstep,id:518,x:32301,y:32262,varname:node_518,prsc:2|A-640-OUT,B-7609-OUT,V-4585-OUT;n:type:ShaderForge.SFN_Vector1,id:640,x:32026,y:32298,varname:node_640,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:7609,x:32026,y:32404,varname:node_7609,prsc:2,v1:0.6;proporder:6784-7960-8225-1729;pass:END;sub:END;*/

Shader "Custom/TriplanarTerrain" {
    Properties {
        _node_6784 ("node_6784", 2D) = "white" {}
        _Tiling ("Tiling", Float ) = 1
        _node_6784_copy ("node_6784_copy", 2D) = "white" {}
        _node_6784_copy_copy ("node_6784_copy_copy", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _node_6784; uniform float4 _node_6784_ST;
            uniform float _Tiling;
            uniform sampler2D _node_6784_copy; uniform float4 _node_6784_copy_ST;
            uniform sampler2D _node_6784_copy_copy; uniform float4 _node_6784_copy_copy_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float2 node_3034 = (i.posWorld.rgb.rb*_Tiling);
                float4 _node_6784_var = tex2D(_node_6784,TRANSFORM_TEX(node_3034, _node_6784));
                float2 node_384 = (i.posWorld.rgb.gr*_Tiling);
                float4 _node_6784_copy_var = tex2D(_node_6784_copy,TRANSFORM_TEX(node_384, _node_6784_copy));
                float node_640 = 0.5;
                float node_7609 = 0.6;
                float3 node_518 = smoothstep( float3(node_640,node_640,node_640), float3(node_7609,node_7609,node_7609), abs(i.normalDir) );
                float2 node_3323 = (i.posWorld.rgb.gb*_Tiling);
                float4 _node_6784_copy_copy_var = tex2D(_node_6784_copy_copy,TRANSFORM_TEX(node_3323, _node_6784_copy_copy));
                float3 diffuseColor = lerp(lerp(_node_6784_var.rgb,_node_6784_copy_var.rgb,node_518.b),_node_6784_copy_copy_var.rgb,node_518.r);
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _node_6784; uniform float4 _node_6784_ST;
            uniform float _Tiling;
            uniform sampler2D _node_6784_copy; uniform float4 _node_6784_copy_ST;
            uniform sampler2D _node_6784_copy_copy; uniform float4 _node_6784_copy_copy_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float2 node_3034 = (i.posWorld.rgb.rb*_Tiling);
                float4 _node_6784_var = tex2D(_node_6784,TRANSFORM_TEX(node_3034, _node_6784));
                float2 node_384 = (i.posWorld.rgb.gr*_Tiling);
                float4 _node_6784_copy_var = tex2D(_node_6784_copy,TRANSFORM_TEX(node_384, _node_6784_copy));
                float node_640 = 0.5;
                float node_7609 = 0.6;
                float3 node_518 = smoothstep( float3(node_640,node_640,node_640), float3(node_7609,node_7609,node_7609), abs(i.normalDir) );
                float2 node_3323 = (i.posWorld.rgb.gb*_Tiling);
                float4 _node_6784_copy_copy_var = tex2D(_node_6784_copy_copy,TRANSFORM_TEX(node_3323, _node_6784_copy_copy));
                float3 diffuseColor = lerp(lerp(_node_6784_var.rgb,_node_6784_copy_var.rgb,node_518.b),_node_6784_copy_copy_var.rgb,node_518.r);
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
