Shader "Gleechi/HandsFS"
{
    Properties
    {
         _c1 ("ColorA", Color) = (1,1,1,1)
         _c2 ("ColorB", Color) = (1,1,1,1)
         _p ("Power", Float) = 2
         _s ("Scale 1/100", Float) = 100
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;         
                UNITY_VERTEX_INPUT_INSTANCE_ID       
            };

            struct v2f
            {  
                float4 vertex : SV_POSITION;                
                float3 normal : NORMAL;
                float3 wpos : UV;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            fixed4 _c1;
            fixed4 _c2;
            float _p;
            float _s;

            v2f vert (appdata v)
            {
                v2f o;

                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_OUTPUT(v2f, o); 
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); 
    
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                o.wpos = mul(v.vertex,unity_ObjectToWorld);
                
                return o;
                
            }

            fixed4 frag (v2f i) : SV_Target
            {
                UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(i);
                float3 d = normalize(_WorldSpaceCameraPos - i.wpos); 
                //float f = abs(dot(f,i.normal));
                float f = 1 - saturate(dot(d,i.normal)/_s);
                //f = 1 - saturate ( dot ( v.normal, viewDir )/_s);
                return lerp(_c1,_c2,pow(f,_p)); 
                //return 
                //eturn f;                
            }
            ENDCG
        }
    }
}
