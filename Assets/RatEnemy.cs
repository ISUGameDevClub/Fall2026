using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatEnemy : MonoBehaviour
{
    //[SerializeField] public GameObject breadcrumb;
    //[SerializeField] public RatHitbox rat_hitbox_script;
    private Vector2 ratStartPos;
    private Vector2 target;
    private List<GameObject> breadcrumbList;
    public float speed;

    void Start()
    {
        ratStartPos = transform.position;
        breadcrumbList = new List<GameObject>();
    }

    private void Update()
    {
        //nearCrumb = rat_hitbox_script.isNearCrumb();
        if (breadcrumbList.Count > 0 && breadcrumbList[0] != null)
        {
            target = breadcrumbList[0].transform.position;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            //target = ratStartPos;
            transform.position = Vector3.MoveTowards(transform.position,ratStartPos, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            // Destroy(gameObject);
            // NOTE: May change to destroy instead of set active = false depending on later systems
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "BreadCrumbPrefab(Clone)")
        {
            breadcrumbList.Add(col.gameObject);
        }
    }
    public void destroyBreadCrumb(GameObject a)
    {
        if (a == breadcrumbList[0])
        {
            breadcrumbList.RemoveAt(0);
            Destroy(a.gameObject);
        }
    }
}