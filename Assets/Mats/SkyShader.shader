Shader "Custom/SkyShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            Cull Front   
            SetTexture [_MainTex] { combine texture }
        }
    }
}