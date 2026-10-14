using JetBrains.Annotations;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Checkpoint CurrentCheckpoint;
     
    public void SetCheckpoint(Checkpoint cp)
    {
        CurrentCheckpoint = cp;
    }

    public void Respawn()
    {
        if (CurrentCheckpoint != null)
        {
            transform.position = Checkpoint.respawnPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
