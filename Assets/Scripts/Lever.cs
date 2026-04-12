using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    private bool on = false;
    private bool playerInRange = false;

    private InputAction interactAction;
    [SerializeField]
    private Transform onPosition;
    [SerializeField]
    private Transform offPosition;
    [SerializeField]
    private GameObject leverHandle;

    [SerializeField] private GameObject interactText; 


    void Start()
    {
        this.interactAction = InputSystem.actions.FindAction("Interact");
        interactText.SetActive(false); 

    }

    void ToggleLever()
    {
        this.on = !this.on;
        if (this.on)
        {
            this.leverHandle.transform.SetPositionAndRotation(this.onPosition.position, this.onPosition.rotation);
        }
        else
        {
            this.leverHandle.transform.SetPositionAndRotation(this.offPosition.position, this.offPosition.rotation);
        }
    }

    void Update()
    {
        if (playerInRange && this.interactAction.WasPressedThisFrame())
        {
            this.ToggleLever();
        }
    }

      private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactText.SetActive(false);
        }
    }
}
