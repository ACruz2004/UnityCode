Shader "Unlit/PS1 Style Shader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TintColor ("Tint Color", Color) = (1,1,1,1)
        _PixelationAmount ("Pixelation Amount", Range(1, 512)) = 128
        _JitterAmount ("Jitter Amount", Range(1, 200)) = 100
        _Blockiness ("Blockiness", Range(1, 100)) = 10
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
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            // Properties
            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _PixelationAmount;
            float _JitterAmount;
            float _Blockiness;


            v2f vert (appdata v)
            {
                v2f o;

                float3 blockyPosition = floor(v.vertex.xyz * _Blockiness) / _Blockiness;

                o.pos = UnityObjectToClipPos(v.vertex);

                o.pos.xy = floor(o.pos.xy * _JitterAmount) / _JitterAmount;

                o.uv = v.uvl
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 pixelatedUV = floor(i.uv * _PixelationAmount) / _PixelationAmount;

                fixed4 texColor = tex2D(_MainTex, pixelatedUV);

                texColor *= _TintColor;

                texColor.rgb = floor(texColor.rgb * 4.0) / 4.0;

                return texColor;
            }
            ENDCG
        }
    }
}
