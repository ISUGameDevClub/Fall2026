using Unity.VisualScripting;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] public GameObject Door;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Door.SetActive(false);
        }

        if (gameObject.IsDestroyed())
        {
            gameObject.SetActive(true);
            Door.SetActive(true);
        }
    }
}
