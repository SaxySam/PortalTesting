Shader "Portals/PortalMask"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
            "RenderPipeline" = "UniversalRenderPipeline"
        }

        HLSLINCLUDE
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        ENDHLSL

        Pass
        {
            Name "PortalMask"

            Stencil
            {
                Ref 1
                Pass replace
            }

            HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                struct VertexIn
                {
                    float4 vertex : POSITION;
                };

                struct VertexOutFragmentIn
                {
                    float4 vertex : SV_POSITION;
                    float4 screenPos : TEXCOORD0;
                };

                VertexOutFragmentIn vert(VertexIn v)
                {
                    VertexOutFragmentIn o;
                    o.vertex = TransformObjectToHClip(v.vertex.xyz);
                    o.screenPos = ComputeScreenPos(o.vertex);
                    return o;
                }

                sampler2D   _MainTex;

                float4 frag(VertexOutFragmentIn IN) : SV_Target
                {
                    float2 uv = IN.screenPos.xy / IN.screenPos.w;
                    float4 color = tex2D(_MainTex, uv);

                    return color;
                }
            ENDHLSL
        }
    }
}
