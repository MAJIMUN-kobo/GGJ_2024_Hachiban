using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class mainCamera : MonoBehaviour
{
    Camera MainCamera;
    Camera UICamera;

    private void Awake()
    {
        MainCamera = GetComponent<Camera>();
        UICamera=GameObject.Find("UICamera").GetComponent<Camera>();
    }

    void Start()
    {
        var cameraData = MainCamera.GetUniversalAdditionalCameraData();
        cameraData.cameraStack.Add(UICamera);
    }
}
