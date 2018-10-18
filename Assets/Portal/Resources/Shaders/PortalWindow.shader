Shader "Custom/PortalWindow"
{
	SubShader
	{
		Tags { "Queue" = "Geometry-1" }

		ColorMask 0 // Don't write to any color channels
		ZWrite off // Don't write to the Depth buffer
		Cull off

		// set all pixels in the portal to 1
		Stencil {
			Ref 1
			Comp Always
			Pass replace
		}

		Pass
		{
		}
	}
}
