using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour

{
    public GameObject CurrentCheckpoint;
    public Checkpoint checkpoint;
    public Transform respawnpoint;
    private Rigidbody2D rigidbody;
    private PlayerController playerController;
    private void Start()
    {
        respawnpoint = gameObject.transform;
        rigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    public void SetCheckpoint(GameObject cp)
    {
        CurrentCheckpoint = cp;
        checkpoint = CurrentCheckpoint.GetComponent<Checkpoint>();
    }

    public void Respawn()
    {
        rigidbody.linearVelocity = Vector3.zero;
        transform.position = respawnpoint.position;
        playerController.resetBreadcrumbCount();
        playerController.inputDisabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PoisonObstacle"))
        {
            //Debug.Log("died");
            Respawn();
        }
    }
    public GameObject GetCheckpoint()
    {
        return CurrentCheckpoint;
    }
}
