using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //[SerializeField]private int breadcrumbs;
    [SerializeField]private int maxBreadcrumbs;
    private PlayerRespawn respawn;
    private PlayerController controller;
    private void Awake()
    {
        respawn = FindAnyObjectByType<PlayerRespawn>();
        controller = FindAnyObjectByType<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&respawn.GetCheckpoint()!=gameObject)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            //Debug.Log("Checkpoint reached!");
            respawn.respawnpoint = playerObject.transform;
            respawn.CurrentCheckpoint = gameObject;
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
