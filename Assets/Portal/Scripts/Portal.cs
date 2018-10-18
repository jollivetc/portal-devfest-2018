using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    private Transform transformCamera;
    private bool frontSide;
    private bool isInside;
    private bool isColliding;

    void Start()
    {
        // Get camera transform
        transformCamera = Camera.main.transform;

        // Start outside
        SetStencilTest(false);
    }

    void Update()
    {
        OnColliding();
    }

    void SetStencilTest(bool inside)
    {
        var stencilTest = inside ? CompareFunction.NotEqual : CompareFunction.Equal;
        Shader.SetGlobalInt("_StencilTest", (int)stencilTest);
    }

    void OnColliding()
    {
        if (!isColliding)
            return;

        bool isInFront = IsInFrontSide();
        if (isInFront != frontSide)
        {
            isInside = !isInside;
            SetStencilTest(isInside);
        }
        frontSide = isInFront;
    }

    bool IsInFrontSide()
    {
        Vector3 worldPos = transformCamera.position + transformCamera.forward * Camera.main.nearClipPlane;
        Vector3 pos = transform.InverseTransformPoint(worldPos);
        return pos.z >= 0 ? true : false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform != transformCamera)
            return;

        frontSide = IsInFrontSide();
        isColliding = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform != transformCamera)
            return;

        isColliding = false;
    }

    void OnDestroy()
    {
        SetStencilTest(true);
    }
}
