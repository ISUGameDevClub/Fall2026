using UnityEngine;

public class PlayerRespawn : MonoBehaviour

{
    public GameObject CurrentCheckpoint;
    Transform respawnpoint;
     
    public void SetCheckpoint(GameObject cp)
    {
        CurrentCheckpoint = cp;
    }

    public void Respawn()
    {
        if (CurrentCheckpoint != null)
        {
            transform.position = respawnpoint.position;
            


        }
    }
     
    void OnTriggerEnter2D(Collider2D collision)
{
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.CompareTag("Checkpoint"))
        {
            Debug.Log("Checkpoint reached!");
            respawnpoint = collision.transform;
            CurrentCheckpoint = collision.gameObject;


        }
        else if (collision.CompareTag("DeathZone"))
        {
            Debug.Log("died");
            Respawn();
        }
    }

    
}
