using UnityEngine;

public class Door : MonoBehaviour
{
    // Smoothly open a door
    public AnimationCurve openSpeedCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0, 1, 0, 0), new Keyframe(0.8f, 1, 0, 0), new Keyframe(1, 0, 0, 0) }); // Controls the open speed at a specific time (ex. the door opens fast at the start then slows down at the end)
    public float openSpeedMultiplier = 2.0f; // Increasing this value will make the door open faster
    public float doorOpenAngle = 90.0f; // Global door open speed that will multiply the openSpeedCurve
    public GameObject CanvasEToOpen; // UI element to show interaction prompt
    public bool canCloseIfOpened = true; // Flag to determine if the door can close once opened
    public bool requiresCheckpoint = false; // Flag to determine if the door needs a checkpoint to open
    public string checkpointName; // Checkpoint name to check before opening

    private bool open = false;
    private bool enter = false;
    private bool isPlayerInRange = false;
    private float defaultRotationAngle;
    private float currentRotationAngle;
    private float openTime = 0;

    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;

        // Set Collider as trigger
        GetComponent<Collider>().isTrigger = true;
    }

    // Main function
    void Update()
    {
        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeedMultiplier * openSpeedCurve.Evaluate(openTime);
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);

        if (Input.GetKeyDown(KeyCode.E) && enter)
        {
            if (!open && CanOpenDoor())
            {
                open = true;
                currentRotationAngle = transform.localEulerAngles.y;
                openTime = 0;
            }
            else if (open && canCloseIfOpened)
            {
                open = false;
                currentRotationAngle = transform.localEulerAngles.y;
                openTime = 0;
            }
        }

        if (!canCloseIfOpened && open && enter)
        {
            CanvasEToOpen.SetActive(false);
        }
    }

    // Function to check if the door can be opened
    private bool CanOpenDoor()
    {
        if (requiresCheckpoint)
        {
            return CheckpointManager.Instance.GetCheckpoint(checkpointName);
        }
        return true;
    }

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasEToOpen.SetActive(true);
            enter = true;
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasEToOpen.SetActive(false);
            enter = false;
        }
    }
}




