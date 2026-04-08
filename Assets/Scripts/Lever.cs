using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    private bool on = false;
    private InputAction interactAction;
    [SerializeField]
    private Transform onPosition;
    [SerializeField]
    private Transform offPosition;
    [SerializeField]
    private GameObject leverHandle;

    void Start()
    {
        this.interactAction = InputSystem.actions.FindAction("Interact");
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
        if (this.interactAction.WasPressedThisFrame())
        {
            this.ToggleLever();
        }

    }
}
