using UnityEngine;

public class PlayerRespawn : MonoBehaviour

{
    public GameObject CurrentCheckpoint;
    Transform respawnpoint;
    private Rigidbody2D rigidbody;
    private void Awake()
    {
        respawnpoint = transform;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetCheckpoint(GameObject cp)
    {
        CurrentCheckpoint = cp;
    }

    public void Respawn()
    {
        if (CurrentCheckpoint != null)
        {
            rigidbody.linearVelocity = Vector3.zero;
            transform.position = respawnpoint.position;
        }
    }
     
    void OnTriggerEnter2D(Collider2D collision)
{
        //Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (collision.CompareTag("Checkpoint"))
        {
            //Debug.Log("Checkpoint reached!");
            respawnpoint = collision.transform;
            CurrentCheckpoint = collision.gameObject;


        }
        else if (collision.CompareTag("DeathZone"))
        {
            //Debug.Log("died");
            Respawn();
        }
    }

    
}
