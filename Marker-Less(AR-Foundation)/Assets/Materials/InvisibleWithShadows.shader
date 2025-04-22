Shader "Custom/InvisibleWithShadows"
{
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        
        Pass
        {
            Name "ShadowPass"
            Tags { "LightMode" = "ShadowCaster" }
        }

        Pass
        {
            Name "InvisiblePass"
            Tags { "LightMode" = "ForwardBase" }
            ZWrite Off
            ColorMask 0
        }
    }
}