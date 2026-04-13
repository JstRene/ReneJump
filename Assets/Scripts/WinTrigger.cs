using UnityEngine;
using UnityEngine.InputSystem;

public class WinTrigger : MonoBehaviour
//Basically Copy Paste Lever with additional text
{
    private bool playerInRange = false;
    private InputAction interactAction;

    [SerializeField] private GameObject interactText; 
    [SerializeField] private GameObject winText; 
    [SerializeField] private Tracker tracker;  

    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

        if (interactText != null)
            interactText.SetActive(false);

        if (winText != null)
            winText.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && interactAction.WasPressedThisFrame())
        {
            WinGame();
        }
    }

    void WinGame()
    {
        if (interactText != null)
            interactText.SetActive(false);

        if (winText != null)
            winText.SetActive(true);

        if (tracker != null)
            tracker.StopTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (interactText != null)
                interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactText != null)
                interactText.SetActive(false);
        }
    }
}