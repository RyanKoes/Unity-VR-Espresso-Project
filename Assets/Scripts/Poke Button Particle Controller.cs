using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeButtonParticleController : MonoBehaviour
{
    public ParticleSystem tooltipParticleSystem1;
    public ParticleSystem tooltipParticleSystem2;

    [Header("Tooltip Cylinder (Fades In Over Time)")]
    public Renderer tooltipCylinderRenderer;
    public float playDuration = 30f;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable pokeButtonInteractable;
    private Material tooltipMaterialInstance;

    private void Awake()
    {
        pokeButtonInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();

        if (pokeButtonInteractable == null)
            Debug.LogError("XRSimpleInteractable component is missing on the PokeButton GameObject.");

        if (tooltipParticleSystem1 == null || tooltipParticleSystem2 == null)
            Debug.LogError("Please assign both tooltip particle systems in the Inspector.");

        if (tooltipCylinderRenderer != null)
        {
            tooltipMaterialInstance = tooltipCylinderRenderer.material;
            
            Color c = tooltipMaterialInstance.color;
            c.a = 0f;
            tooltipMaterialInstance.color = c;
        }
    }

    private void OnEnable()
    {
        if (pokeButtonInteractable != null)
            pokeButtonInteractable.selectEntered.AddListener(OnButtonPressed);
    }

    private void OnDisable()
    {
        if (pokeButtonInteractable != null)
            pokeButtonInteractable.selectEntered.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        tooltipParticleSystem1?.Play();
        tooltipParticleSystem2?.Play();
        
        if (tooltipCylinderRenderer != null)
            StartCoroutine(FadeInTooltipCylinder());
        
        Invoke(nameof(StopParticleSystems), playDuration);
    }

    private System.Collections.IEnumerator FadeInTooltipCylinder()
    {
        if (tooltipMaterialInstance == null)
            yield break;

        float elapsed = 0f;
        Color c = tooltipMaterialInstance.color;

        while (elapsed < playDuration)
        {
            float t = elapsed / playDuration;
            c.a = Mathf.Lerp(0f, 1f, t);
            tooltipMaterialInstance.color = c;

            elapsed += Time.deltaTime;
            yield return null;
        }
        
        c.a = 1f;
        tooltipMaterialInstance.color = c;
    }

    private void StopParticleSystems()
    {
        tooltipParticleSystem1?.Stop();
        tooltipParticleSystem2?.Stop();
    }
}
