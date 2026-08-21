using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TrashItem : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void ResetTrash()
    {
        rb.isKinematic = true;
        
        rb.linearVelocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero;

        transform.SetPositionAndRotation(startPosition, startRotation);

        rb.isKinematic = false;
        gameObject.SetActive(true); 
    }
}