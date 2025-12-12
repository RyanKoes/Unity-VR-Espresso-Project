using UnityEngine;

public class FrothController : MonoBehaviour
{
    public ParticleSystem tooltipParticleSystem; 
    public GameObject cylinder; 
    public GameObject tooltipCylinder; 
    public float tiltThreshold = -40f;        
    public float uprightResetAngle = -10f;
    public float tooltipDuration = 7f;        

    private bool isTooltipActive = false;
    private bool hasPlayedOnce = false;
    private float tooltipTimer = 0f;

    private Material cylinderMaterial;
    private Material tooltipMaterial;

    private void Start()
    {
        if (cylinder != null)
        {
            Renderer renderer = cylinder.GetComponent<Renderer>();
            if (renderer != null)
            {
                cylinderMaterial = renderer.material;
            }
            else
            {
                Debug.LogError("No Renderer found on the cylinder.");
            }
        }
        
        if (tooltipCylinder != null)
        {
            Renderer renderer = tooltipCylinder.GetComponent<Renderer>();
            if (renderer != null)
            {
                tooltipMaterial = renderer.material;
                Color c = tooltipMaterial.color;
                c.a = 0f;
                tooltipMaterial.color = c;
            }
        }

        if (tooltipParticleSystem == null)
            Debug.LogError("Tooltip particle system not assigned.");
    }

    private void Update()
    {
        float tiltAngle = transform.localEulerAngles.z;
        if (tiltAngle > 180) tiltAngle -= 360;
        
        if (!isTooltipActive && tiltAngle > uprightResetAngle)
        {
            hasPlayedOnce = false;
        }

        // Trigger ONLY if:
        // - jug is tilted past threshold
        // - tooltip is not already active
        // - tooltip hasn't already played during this tilt event
        if (tiltAngle < tiltThreshold && !isTooltipActive && !hasPlayedOnce)
        {
            TriggerTooltip();
        }

        if (isTooltipActive)
        {
            tooltipTimer += Time.deltaTime;
            
            if (cylinderMaterial != null)
            {
                float alpha = Mathf.Clamp01(1f - (tooltipTimer / tooltipDuration));
                Color color = cylinderMaterial.color;
                color.a = alpha;
                cylinderMaterial.color = color;
            }
            
            if (tooltipMaterial != null)
            {
                float alpha = Mathf.Clamp01(tooltipTimer / tooltipDuration);
                Color color = tooltipMaterial.color;
                color.a = alpha;
                tooltipMaterial.color = color;
            }
            
            if (tooltipTimer >= tooltipDuration)
            {
                StopTooltip();
            }
        }
    }

    private void TriggerTooltip()
    {
        isTooltipActive = true;
        hasPlayedOnce = true;
        tooltipTimer = 0f;

        tooltipParticleSystem?.Play();
    }

    private void StopTooltip()
    {
        isTooltipActive = false;
        tooltipTimer = 0f;

        tooltipParticleSystem?.Stop();
    }
}
