using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(AROcclusionManager))]
public class AROcclusionQualityChanger : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown depthQualityDropDown;

    private AROcclusionManager occlusionManager;

    private void Awake()
    {
        occlusionManager = GetComponent<AROcclusionManager>();
        depthQualityDropDown.onValueChanged.AddListener(quality =>
        {
        EnvironmentDepthMode depthMode = (EnvironmentDepthMode)quality;
        occlusionManager.requestedEnvironmentDepthMode = depthMode;
        Logger.Instance.LogInfo($"Depth Mode was  set to:{ depthMode}");
        });
    }
}
