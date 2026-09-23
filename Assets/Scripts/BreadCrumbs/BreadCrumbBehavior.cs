using UnityEngine;

public class BreadCrumbBehavior : MonoBehaviour
{
    private bool collectable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collectable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && collectable)
        {
            //Debug.Log("Destroy gameobject");
            coll.gameObject.GetComponent<PlayerController>().BreadCrumbAmount--;
            Destroy(gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            collectable = true;
           // Debug.Log("let the player pickup the breadcrumbs");
            //Debug.Log("Add gameobject to breadcrumbarray")
        }
    }
}
