using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ToggleMusic : MonoBehaviour
{
    public AudioSource musicSource; 
    private bool isMusicPlaying = true; 
    private XRSimpleInteractable pokeButtonInteractable;

    private void Awake()
    {
        // Get the XRSimpleInteractable component from the button
        pokeButtonInteractable = GetComponent<XRSimpleInteractable>();

        if (pokeButtonInteractable == null)
        {
            Debug.LogError("XRSimpleInteractable component is missing on the PokeButton GameObject.");
        }
        
        if (musicSource == null)
        {
            Debug.LogError("AudioSource component is not assigned.");
        }
    }

    private void OnEnable()
    {
        if (pokeButtonInteractable != null)
        {
            pokeButtonInteractable.selectEntered.AddListener(OnButtonPressed);
        }
    }

    private void OnDisable()
    {
        if (pokeButtonInteractable != null)
        {
            pokeButtonInteractable.selectEntered.RemoveListener(OnButtonPressed);
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (musicSource != null)
        {
            if (isMusicPlaying)
            {
                musicSource.Pause();
                isMusicPlaying = false;
            }
            else
            {
                musicSource.Play();
                isMusicPlaying = true;
            }
        }
    }
}