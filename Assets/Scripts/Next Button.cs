using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TriggerNextMessage : MonoBehaviour
{
    public GameObject textElement;
    private ShowMessageFromList showMessageScript;
    private XRSimpleInteractable buttonInteractable;

    private void Awake()
    {
        // Get the XRSimpleInteractable component from the button
        buttonInteractable = GetComponent<XRSimpleInteractable>();

        if (buttonInteractable == null)
        {
            Debug.LogError("XRSimpleInteractable component is missing on the button GameObject.");
        }

        // Get the ShowMessageFromList script from the Text element
        if (textElement != null)
        {
            showMessageScript = textElement.GetComponent<ShowMessageFromList>();
            if (showMessageScript == null)
            {
                Debug.LogError("ShowMessageFromList script is not attached to the Text element.");
            }
        }
        else
        {
            Debug.LogError("Text element is not assigned.");
        }
    }

    private void OnEnable()
    {
        if (buttonInteractable != null)
        {
            buttonInteractable.selectEntered.AddListener(OnButtonPressed);
        }
    }

    private void OnDisable()
    {
        if (buttonInteractable != null)
        {
            buttonInteractable.selectEntered.RemoveListener(OnButtonPressed);
        }
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (showMessageScript != null)
        {
            showMessageScript.NextMessage();
        }
    }
}