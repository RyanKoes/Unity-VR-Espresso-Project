using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeButtonResetSceneDirect : MonoBehaviour
{
    // Reference to the button's interactable component
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable pokeButtonInteractable; 

    private void Awake()
    {
        // Get the XRSimpleInteractable component from the button
        pokeButtonInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();

        if (pokeButtonInteractable == null)
        {
            Debug.LogError("XRSimpleInteractable component is missing on the PokeButton GameObject.");
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
        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}