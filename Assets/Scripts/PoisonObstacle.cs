using UnityEngine;

public class PoisonObstacle : MonoBehaviour
{
    public GameObject player;
    public Transform RespawnPoint; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = RespawnPoint.position; 
        }
    }
}
