using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SteamController : MonoBehaviour
{
    public ParticleSystem tooltipParticleSystem;
    public float playDuration = 15f;

    private XRSimpleInteractable steamButtonInteractable;

    private void Awake()
    {
        // Get the XRSimpleInteractable component from the button
        steamButtonInteractable = GetComponent<XRSimpleInteractable>();

        if (steamButtonInteractable == null)
        {
            Debug.LogError("XRSimpleInteractable component is missing on the SteamButton GameObject.");
        }
        
        if (tooltipParticleSystem == null)
        {
            Debug.LogError("Tooltip particle system is not assigned.");
        }
    }

    private void OnEnable()
    {
        if (steamButtonInteractable != null)
        {
            steamButtonInteractable.selectEntered.AddListener(OnButtonPressed);
        }
    }

    private void OnDisable()
    {
        if (steamButtonInteractable != null)
        {
            steamButtonInteractable.selectEntered.RemoveListener(OnButtonPressed);
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (tooltipParticleSystem != null)
        {
            tooltipParticleSystem.Play();
        }
        
        Invoke(nameof(StopTooltipParticleSystem), playDuration);
    }

    private void StopTooltipParticleSystem()
    {
        if (tooltipParticleSystem != null)
        {
            tooltipParticleSystem.Stop();
        }
    }
}