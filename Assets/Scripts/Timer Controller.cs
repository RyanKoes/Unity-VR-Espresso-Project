using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PokeButtonTimerController : MonoBehaviour
{
    public Timer timer; // Timer Script
    private int buttonPressCount = 0;
    private XRSimpleInteractable pokeButtonInteractable;

    private void Awake()
    {
        // Get the XRSimpleInteractable component from the button
        pokeButtonInteractable = GetComponent<XRSimpleInteractable>();

        if (pokeButtonInteractable == null)
        {
            Debug.LogError("XRSimpleInteractable component is missing on the PokeButton GameObject.");
        }
        
        if (timer == null)
        {
            Debug.LogError("Timer script is not assigned.");
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
        // Cycle through start, stop, and reset
        buttonPressCount++;
        switch (buttonPressCount % 3)
        {
            case 1:
                timer.StartTimer();
                break;
            case 2:
                timer.StopTimer();
                break;
            case 0:
                timer.ResetTimer();
                break;
        }
    }
}