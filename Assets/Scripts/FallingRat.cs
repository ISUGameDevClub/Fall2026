using Unity.VisualScripting;
using UnityEngine;

public class FallingRat : MonoBehaviour
{
    // the player
    [SerializeField] private GameObject player;

    // how fast the rat falls
    [SerializeField] private float fallSpeed;

    // range of where the rats can spawn in relation to the player
    [SerializeField] private float spawnRange;

    // how far above the player the rat spawns at
    [SerializeField] private float startDistance;

    // how far below the player the rat despawns at
    [SerializeField] private float endDistance;

    void Start()
    {
        // set up starting values
        float startPoint = player.GetComponent<Transform>().position.x + Random.Range(-spawnRange, spawnRange);
        GetComponent<Transform>().position = new Vector3(startPoint, player.GetComponent<Transform>().position.y + startDistance, 0);
    }

    void Update()
    {
        if (GetComponent<Transform>().position.y > player.GetComponent<Transform>().position.y - endDistance)
        {
            GetComponent<Transform>().position -= new Vector3(GetComponent<Transform>().position.x, Time.deltaTime * fallSpeed, 0);
        } else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == player.name)
        {
            if (player.GetComponent<PlayerController>().BreadCrumbAmount > 0)
            {
                player.GetComponent<PlayerController>().BreadCrumbAmount--;
            }
        }
    }
}
