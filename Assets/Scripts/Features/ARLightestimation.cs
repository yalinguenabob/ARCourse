using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARLightestimation : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI averageBrightnessText;

    [SerializeField]
    private TextMeshProUGUI colorTemperatureText;

    [SerializeField]
    private TextMeshProUGUI colorCorrectionText;

    [Header("Mappings")]
    [SerializeField]
    private GameObject worldspaceObject;

    private Light arLight;
    private ARCameraManager arCameraManager;

    private float? brightness;

    private float? colorTemperature;

    private Color? colorCorrection;

    private void Awake()
    {
        arLight = FindObjectOfType<Light>();
        arCameraManager = FindObjectOfType<ARCameraManager>();

        PopulateLightestimaionValues();
    }

    private void OnEnable()
    {
        arCameraManager.frameReceived += ArCameraManager_frameReceived;
        Application.onBeforeRender += OnBeforeRender;
    }

    private void OnDisable()
    {
        arCameraManager.frameReceived -= ArCameraManager_frameReceived;
        Application.onBeforeRender -= OnBeforeRender;
    }

    private void ArCameraManager_frameReceived(ARCameraFrameEventArgs obj)
    {
        Logger.Instance.LogInfo("AR Camera frame Received");
        if (obj.lightEstimation.averageBrightness.HasValue) 
        {
            brightness = obj.lightEstimation.averageBrightness;
            arLight.intensity = brightness.Value;
        }

        if (obj.lightEstimation.averageColorTemperature.HasValue) 
        {
            colorTemperature = obj.lightEstimation.averageColorTemperature;
            arLight.colorTemperature = colorTemperature.Value;
        }

        if (obj.lightEstimation.colorCorrection.HasValue)
        {
            colorCorrection = obj.lightEstimation.colorCorrection;
            arLight.color = colorCorrection.Value;

        }

        PopulateLightestimaionValues();
    }

    private void PopulateLightestimaionValues()
    {
        averageBrightnessText.text = $"Avearge Brightness: {brightness}";
        colorTemperatureText.text = $"Avearge colorTemperature: {colorTemperature}";
        colorCorrectionText.text = $"Avearge ColorCorrection: {colorCorrection}";
    }

    private void OnBeforeRender()
    {
        var camera = FindObjectOfType<XROrigin>().Camera;
        if(camera && worldspaceObject)
        {
            worldspaceObject.transform.position = camera.transform.position + camera.transform.forward;
        }
    }
}