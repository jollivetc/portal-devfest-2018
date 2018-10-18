using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SimplePortal : MonoBehaviour
{
    Transform transformCamera;
    private bool isInside;

    // Use this for initialization
    void Start()
    {
        transformCamera = Camera.main.transform;

        SetStencilTest(false);
    }

    private void SetStencilTest(bool inside)
    {
        var StencilTest = inside ? CompareFunction.NotEqual : CompareFunction.Equal;
        Shader.SetGlobalFloat("_StencilTest", (int)StencilTest);
    }

    private void OnDestroy()
    {
        SetStencilTest(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform != transformCamera)
            return;

        isInside = !isInside;
        SetStencilTest(isInside);
    }
}