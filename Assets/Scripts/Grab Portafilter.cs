using UnityEngine;

public class PortafilterGrab : MonoBehaviour
{
    [Header("Grab Settings")]
    public Transform handTransform;
    public bool isGrabbed = false;

    public Collider portafilterCollider;
    private bool handInside = false;
    private void Awake()
    {
        portafilterCollider = GetComponent<Collider>();
        if (portafilterCollider == null)
        {
            Debug.LogError("PortafilterGrab requires a Collider on the same GameObject.");
        }
    }

    public void TryGrab()
    {
        if (!handInside)
        {
            Debug.Log("Hand not inside collider — cannot grab.");
            return;
        }

        GrabPortafilter();
    }

    private void GrabPortafilter()
    {
        transform.position = handTransform.position;
        transform.rotation = handTransform.rotation;
        transform.Rotate(0f, 40f, 90f);
        Vector3 V = new Vector3(-0.01f, 0.08f, 0.015f);
        transform.Translate(V);

        transform.SetParent(handTransform);

        isGrabbed = true;
        Debug.Log("Portafilter grabbed!");
    }

    public void Release()
    {
        transform.SetParent(null);
        isGrabbed = false;
        Debug.Log("Portafilter released.");
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("XRHand"))
        {
            handInside = true;
            Debug.Log("Hand entered portafilter collider");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("XRHand"))
        {
            handInside = false;
            Debug.Log("Hand exited portafilter collider");
        }
    }

}
