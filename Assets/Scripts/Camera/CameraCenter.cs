using UnityEditor;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
    [SerializeField] private Color gizmoColor = Color.cyan;
    [SerializeField] private float radius = 0.25f;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        // Wireframe sphere at center (functions like a 3D circle from all angles)
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
