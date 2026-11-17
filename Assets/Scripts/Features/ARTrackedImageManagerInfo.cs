using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ARTrackedImageManagerInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectToInstanntiate;

    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }
    private void Start()
    {
        Logger.Instance.LogInfo("ARTrackedImageManager is satrting");

        if (trackedImageManager.subsystem == null)
        {
            Logger.Instance.LogWarning("Image tracking is NOT supporting");
            return;
        }

        if (!trackedImageManager.descriptor.supportsImageValidation)
            Logger.Instance.LogWarning("Not Supported: ImageValidation");
        if (!trackedImageManager.descriptor.supportsMutableLibrary)
            Logger.Instance.LogWarning("Not Suportesd: MutableLibrary");
        if (!trackedImageManager.descriptor.supportsMovingImages)
            Logger.Instance.LogWarning("Not SUpported: MovingImages");
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += TrackedImagesChanged;
    }

   private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= TrackedImagesChanged;
    }

    private void TrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            Logger.Instance.LogInfo($"New image added :{trackedImage.trackableId}");
            UpdateTrackingInfo(trackedImage);
        }

        foreach (var trackedImage in args.updated)
        {
            Logger.Instance.LogInfo($"New image updated :{trackedImage.trackableId}");
            UpdateTrackingInfo(trackedImage);
        }
    }

    private void UpdateTrackingInfo(ARTrackedImage trackedImage)
    {
        // get UI gameObject
        var ui = trackedImage.transform.GetComponentInChildren<Canvas>();

        // get text labels
        var imageTextBoxes = ui.GetComponentsInChildren<TextMeshProUGUI>();

        if(imageTextBoxes.Length > 0 )
        {
            imageTextBoxes[0].text = $"Imgae name:{trackedImage.referenceImage.name}";
            imageTextBoxes[1].text = $"Image Information:\n\n Image id : {trackedImage.referenceImage.guid}\n\n" +
                $"Tracking State :{trackedImage.trackingState} \n\n Referece:{trackedImage.referenceImage.size} meter(s)";
        }

        // Get the content GameObject

        var contentArea = trackedImage.transform.GetChild(1);
        if(contentArea != null && objectToInstanntiate?.Length> 0)
        {
            var imageContent = contentArea.GetComponent<ARTrackImageContent>();
            if (!imageContent.ContentAdded) 
            {
                int randomSpawn = UnityEngine.Random.Range(0, objectToInstanntiate.Length );
                Instantiate(objectToInstanntiate[randomSpawn], contentArea.transform);
                imageContent.ContentAdded = true;
            }
        }
    }
}
