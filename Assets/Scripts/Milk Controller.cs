using UnityEngine;

public class MilkKartonTooltipController : MonoBehaviour
{
    public ParticleSystem milkParticleSystem;
    public GameObject tooltipCylinder;
    public float tiltThreshold = -40f;
    public float uprightResetAngle = -10f;
    public float tooltipDuration = 5f;

    private bool isTooltipActive = false;
    private bool hasShownTooltip = false;
    private float tooltipTimer = 0f;
    private Material tooltipMaterial;

    private void Start()
    {
        if (tooltipCylinder != null)
        {
            Renderer renderer = tooltipCylinder.GetComponent<Renderer>();
            if (renderer != null)
            {
                tooltipMaterial = renderer.material;
                Color color = tooltipMaterial.color;
                color.a = 0f;
                tooltipMaterial.color = color;
            }
        }

        if (milkParticleSystem == null)
            Debug.LogError("Milk particle system is not assigned.");
    }

    private void Update()
    {
        float tiltAngle = transform.localEulerAngles.z;
        if (tiltAngle > 180) tiltAngle -= 360;
        
        if (!isTooltipActive && tiltAngle > uprightResetAngle)
        {
            hasShownTooltip = false;
        }
        
        if (tiltAngle < tiltThreshold && !isTooltipActive && !hasShownTooltip)
        {
            TriggerTooltip();
        }

        if (isTooltipActive)
        {
            tooltipTimer += Time.deltaTime;

            if (tooltipMaterial != null)
            {
                float alpha = Mathf.Clamp01(tooltipTimer / tooltipDuration);
                Color c = tooltipMaterial.color;
                c.a = alpha;
                tooltipMaterial.color = c;
            }

            if (tooltipTimer >= tooltipDuration)
            {
                StopTooltipCompletely();
            }
        }
    }

    private void TriggerTooltip()
    {
        isTooltipActive = true;
        hasShownTooltip = true;
        tooltipTimer = 0f;

        milkParticleSystem?.Play();

        if (tooltipMaterial != null)
        {
            Color c = tooltipMaterial.color;
            c.a = 0f;
            tooltipMaterial.color = c;
        }
    }

    private void StopTooltipCompletely()
    {
        isTooltipActive = false;
        tooltipTimer = 0f;

        milkParticleSystem?.Stop();
    }
}
