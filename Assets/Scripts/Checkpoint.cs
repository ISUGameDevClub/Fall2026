using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //[SerializeField]private int breadcrumbs;
    [SerializeField]private int maxBreadcrumbs;
    private PlayerRespawn respawn;
    private PlayerController controller;
    private GameObject playerObject;
    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        respawn = playerObject.GetComponent<PlayerRespawn>();
        controller = playerObject.GetComponent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//&&respawn.GetCheckpoint()!=gameObject)
        {
            //Debug.Log("Checkpoint reached!");
            Vector2 a = playerObject.transform.position;
            respawn.respawnpoint = a;
            //respawn.CurrentCheckpoint = gameObject;
            respawn.checkpoint = gameObject.GetComponent<Checkpoint>();
            //controller.setBreadCrumbAmount(breadcrumbs);
            controller.setBreadCrumbLimit(maxBreadcrumbs);
        }
    }
    public int getMaxBreadcrumbs()
    {
        return maxBreadcrumbs;
    }
    //public int getBreadcrumbs()
    //{
    //    return breadcrumbs;
    //}

}
