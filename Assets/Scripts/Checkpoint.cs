using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]private int breadcrumbs;
    [SerializeField]private int maxBreadcrumbs;

    public int getMaxBreadCrumbs()
    {
        return maxBreadcrumbs;
    }
    public int getBreadcrumbs()
    {
        return breadcrumbs;
    }

}
