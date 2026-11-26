using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour

{
    //public GameObject CurrentCheckpoint;
    public Checkpoint checkpoint;
    public Vector2 respawnpoint;
    private Rigidbody2D rigidbody;
    private PlayerController playerController;
    GameObject[] rats;
    private void Start()
    {
        Vector2 a = transform.position;
        respawnpoint = a;
        rigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        rats = GameObject.FindGameObjectsWithTag("Rat");
    }

    //public void SetCheckpoint(GameObject cp)
    //{
    //    CurrentCheckpoint = cp;
    //    checkpoint = CurrentCheckpoint.GetComponent<Checkpoint>();
    //}

    public void Respawn()
    {
        rigidbody.linearVelocity = Vector3.zero;
        transform.position = respawnpoint;
        playerController.resetBreadcrumbCount();
        playerController.inputDisabled = false;

        
        foreach(GameObject a in rats)
        {
            a.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PoisonObstacle"))
        {
            //Debug.Log("died");
            Respawn();
        }
    }
    //public GameObject GetCheckpoint()
    //{
    //    return CurrentCheckpoint;
    //}
}
