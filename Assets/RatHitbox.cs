using UnityEngine;

public class RatHitbox : MonoBehaviour
{
    [SerializeField] private GameObject breadcrumb;
    private RatEnemy enemyScript;
    private bool nearCrumb = false;

    private void Awake()
    {
        enemyScript = transform.parent.GetComponent<RatEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breadcrumb")
        {
            nearCrumb = true;
            enemyScript.SetTarget(collision.transform);
        }
    }

    public bool isNearCrumb()
    {
        return nearCrumb;
    }
}