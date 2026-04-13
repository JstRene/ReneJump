using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    [SerializeField] private Tracker tracker;

    void OnTriggerEnter(Collider other)
    {
        CharacterController cc = other.gameObject.GetComponent<CharacterController>();
        
        if (cc != null)
        {
            Respawn(cc);
        }
    }

    void Respawn(CharacterController cc)
    {
        cc.enabled = false;
        cc.gameObject.transform.position = respawnPoint.position;
        cc.enabled = true;

        if (tracker != null)
        {
            tracker.AddRespawn();
        }
    }
}