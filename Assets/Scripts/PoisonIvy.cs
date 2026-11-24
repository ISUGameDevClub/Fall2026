using System;
using UnityEngine;

public class PoisonIvy : MonoBehaviour
{
    // the player
    [SerializeField] private GameObject player;
    // the number of breadcrumbs to lose
    [SerializeField] private int numCrumbLost;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == player.name)
        {
            if (player.GetComponent<PlayerController>().BreadCrumbAmount - numCrumbLost >= 0)
            {
                player.GetComponent<PlayerController>().BreadCrumbAmount -= numCrumbLost;
            } else if (player.GetComponent<PlayerController>().BreadCrumbAmount > 0)
            {
                player.GetComponent<PlayerController>().BreadCrumbAmount = 0;
            }
        }
    }
}
