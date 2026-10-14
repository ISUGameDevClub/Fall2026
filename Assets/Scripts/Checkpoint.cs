using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform player;
    public static Vector3 respawnPosition;
    public static bool checkpointReached = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.CompareTag("Player"))
            {
               respawnPosition= transform. position;
                checkpointReached = true;

                Debug.Log("Checkpoint reached!");

            }

        }
           
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
