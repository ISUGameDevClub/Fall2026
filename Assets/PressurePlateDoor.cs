using System.Runtime.CompilerServices;
using UnityEngine;

public class PressurePlateDoor : MonoBehaviour
{
    [SerializeField] public GameObject Door;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Door.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") // can add another object that works for pressure plate if needed
        {
            Door.SetActive(true);
        }
    }
}
