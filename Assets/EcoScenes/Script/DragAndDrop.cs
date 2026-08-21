using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragAndDrop : MonoBehaviour
{
    [Header("Distance Settings")]
    [SerializeField] private float pickupRange = 5f; 
    [SerializeField] private float holdDistance = 2f; 

    private Rigidbody rb;
    private Camera mainCamera;
    private bool isGrabbed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) TryGrabObject();
        
        if (Input.GetMouseButtonUp(0) && isGrabbed) ReleaseObject();
    }

    private void FixedUpdate()
    {
        if (isGrabbed)
        {
            Vector3 holdPosition = mainCamera.transform.position + (mainCamera.transform.forward * holdDistance);
            rb.MovePosition(holdPosition);
        }
    }

    private void TryGrabObject()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                float distance = Vector3.Distance(mainCamera.transform.position, transform.position);

                if (distance <= pickupRange)
                {
                    isGrabbed = true;
                    rb.useGravity = false;
                }
            }
        }
    }

    private void ReleaseObject()
    {
        isGrabbed = false;
        rb.useGravity = true;
    }
}