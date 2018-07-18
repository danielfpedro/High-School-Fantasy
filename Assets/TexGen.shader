 
Shader "Mobile/Spheremap"
{
     Properties
     {
        _EnvMap ("EnvMap", 2D) = "black" { TexGen SphereMap }
     }
 
     SubShader
     {
        Lighting on
        Tags {"Queue" = "Geometry"}
 
        Pass
        {  
            BindChannels
            {
                Bind "Vertex", vertex
                Bind "normal", normal
            }
            Material
            {
                Diffuse [_Color]
                Ambient [_Color]
            }
 
            SetTexture [_EnvMap]
            {
                combine texture + primary
            }
        }
    }
}