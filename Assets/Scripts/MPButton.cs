using System.Runtime.CompilerServices;
using UnityEngine;

public class MPButton : MonoBehaviour
{
    [SerializeField] public PPPlatform platform;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            platform.PowerPlatform(true);
            //This should be when you stand on the button. It sets the 
            //moving platform to be active, which would be that it is moving. 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            platform.PowerPlatform(false);
            //This should be when you get off the button. It sets the 
            //moving platform to not be active, which would it being stopped. 
        }
    }
}
