using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class ARPlaneDetectInfo : MonoBehaviour
{

    private ARPlaneManager planeManager;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        planeManager.planesChanged += PlanesChanged;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= PlanesChanged;
    }

    private void PlanesChanged(ARPlanesChangedEventArgs args)
    {
        DisplayPlanesChnaged("Plane Added", args.added);
        DisplayPlanesChnaged("Plane Updated", args.updated);
        DisplayPlanesChnaged("Plane removed", args.removed);
    }

    private void DisplayPlanesChnaged(string action, IEnumerable<ARPlane> planes)
    {
        foreach (ARPlane plane in planes)
        {
            Logger.Instance.LogInfo($"{action}: ARPlane tackableId({plane.trackableId})");
        }
    }
}
