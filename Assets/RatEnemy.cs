using System;
using Unity.VisualScripting;
using UnityEngine;

public class RatEnemy : MonoBehaviour
{
    [SerializeField] public GameObject breadcrumb;
    [SerializeField] public RatHitbox rat_hitbox_script;
    [SerializeField] public GameObject rat_starting_position;
    public Transform target;
    public Transform rat_transform;
    public float speed;
    public bool nearCrumb = false;

    void Start()
    {
        nearCrumb = rat_hitbox_script.isNearCrumb();
        rat_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        nearCrumb = rat_hitbox_script.isNearCrumb();
        if (nearCrumb)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            if (rat_transform.position == rat_starting_position.transform.position)
            {
                SetTarget(null);
            }
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

        if (collision.gameObject.tag == "Breadcrumb")
        {
            Destroy(breadcrumb);
            SetTarget(rat_starting_position.transform);
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}