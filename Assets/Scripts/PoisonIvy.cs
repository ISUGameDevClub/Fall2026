using System;
using UnityEngine;

public class PoisonIvy : MonoBehaviour
{
    // the player
    [SerializeField] private GameObject player;
    // the number of breadcrumbs to lose
    [SerializeField] private int numCrumbLost;
    private PlayerController pc;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.name == player.name)
        {
            if (pc.BreadCrumbAmount<pc.BreadCrumbLimit)
            {
                //player.GetComponent<PlayerController>().BreadCrumbAmount = numCrumbLost;
                pc.BreadCrumbAmount += numCrumbLost;
            }
            // else if (player.GetComponent<PlayerController>().BreadCrumbAmount > 0)
            //{
            //    player.GetComponent<PlayerController>().BreadCrumbAmount = 0;
            //}
        }
    }
}
