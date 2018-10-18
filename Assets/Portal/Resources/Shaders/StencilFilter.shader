/*
 *Most basic shader for only rendereing objects depending on the stencil buffer
 *And the state of the global _StencilTest property
 */

Shader "Custom/StencilFilter"
{
	Properties
	{
		_Color ("Color", Color) = (1,1,1,1)
	}

	SubShader
	{	
		Color [_Color]

		//Only render if pass the stencil buffer test i.e. equal or not equal to 1
		Stencil {
			Ref 1
			Comp [_StencilTest]
		}

		Pass
		{
		}
	}
}
