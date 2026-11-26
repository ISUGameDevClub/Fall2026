using UnityEngine;

public class WaterHazard : MonoBehaviour
{   
    private Vector2 respawnPoint;
    [SerializeField] private float safeDistance = 0.5f;
    private PlayerController pc;
    private Collider2D player_collider;
    private Collider2D water_collider;

    void Start()
    {
        pc = PlayerController.instance;
        water_collider = GetComponent<Collider2D>();

        if (pc != null)
        {
            player_collider = pc.GetComponent<Collider2D>();
        }

        if (pc == null || player_collider == null)
        {
            Debug.LogError("PlayerController not found");
        }
    }

    void Update()
    {
        if (pc == null || player_collider == null || pc.getGrounded() == false)
        {
            return;
        }

        float distance = water_collider.Distance(player_collider).distance;
        if (distance > safeDistance)
        {
           respawnPoint = pc.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = respawnPoint;
            if(pc.BreadCrumbAmount<pc.BreadCrumbLimit)
            pc.BreadCrumbAmount++;
            
            // Debug.Log("Breadcrumbs: " + breadcrumbs);
        }
        else
        {
            return;
        }

        if (collision.attachedRigidbody != null)
        {
            collision.attachedRigidbody.linearVelocity = Vector2.zero;
        }
    }
}