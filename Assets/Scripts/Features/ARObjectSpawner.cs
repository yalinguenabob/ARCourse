using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ObjectToSpawn;
    private GameObject ObjectSpawned;

    [SerializeField]
    private TrackableType trackableType;
    private ARRaycastManager raycastManager;

    private static List<ARRaycastHit> hitList = new List<ARRaycastHit>();

    private InputAction pressAction;

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        pressAction = new InputAction("touch", binding: "<Pointer>/press");
    }

    private void OnEnable()
    {
        pressAction.Enable();
    }

    private void OnDisable ()
    {
        pressAction.Disable();
    }
    private void Update()
    {
        var isPressed = pressAction.IsPressed();
        if (!isPressed) return;

        var touchPosition = Pointer.current.position.ReadValue(); // ScreenPosition
        if(raycastManager.Raycast(touchPosition, hitList, trackableType))
        {
            var hitPose = hitList[0].pose;
            //Logger.Instance.LogInfo($"Plane  or Future Point hit with pose : {hitPose}");

            if(ObjectSpawned == null)
            {
                ObjectSpawned = Instantiate(ObjectToSpawn, hitPose.position, hitPose.rotation);
            }
            else
            {
                ObjectSpawned.transform.position = hitPose.position;
            }
        }
    }

}
