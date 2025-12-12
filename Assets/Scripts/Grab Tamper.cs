using UnityEngine;

public class GrabTamper : MonoBehaviour
{
    [Header("Grab Settings")]
    public Transform handTransform;
    private bool isGrabbed = false;

    public Collider tamperCollider;
    private bool handInside = false;
    
    private void Awake()
    {
        tamperCollider = GetComponent<Collider>();
        if (tamperCollider == null)
        {
            Debug.LogError("TamperGrab requires a Collider on the same GameObject.");
        }
    }

    public void TryGrab()
    {
        if (!handInside)
        {
            Debug.Log("Hand not inside collider — cannot grab.");
            return;
        }

        TamperGrab();
    }

    private void TamperGrab()
    {
        transform.position = handTransform.position;
        transform.rotation = handTransform.rotation;
        transform.Rotate(0f, 0f, 90f);
        Vector3 V = new Vector3(-0.02f, -0.075f, 0.02f);
        transform.Translate(V);

        transform.SetParent(handTransform);

        isGrabbed = true;
        Debug.Log("Tamper grabbed!");
    }

    public void Release()
    {
        transform.SetParent(null);
        isGrabbed = false;
        Debug.Log("Tamper released.");
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("XRHand"))
        {
            handInside = true;
            Debug.Log("Hand entered tamper collider");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("XRHand"))
        {
            handInside = false;
            Debug.Log("Hand exited tamper collider");
        }
    }

}
