using System;
using System.Runtime.CompilerServices;
using Unity.AppUI.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraLockZone : MonoBehaviour
{
    [Header("Zone Settings")]
    [Tooltip("How far out the camera zooms out")]
    [SerializeField] float cameraZoom;
    [Header("Gizmo Settings")]
    [SerializeField] private Color gizmoColor = Color.cyan;
    [SerializeField] private float centerRadius = 0.25f;

    [SerializeField] private GameObject center;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        center = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        Vector3 targetPos = new Vector3(center.transform.position.x, center.transform.position.y, -10);

        float height = cameraZoom * 2f;
        float width = height * 16f / 9f;

        Gizmos.DrawWireCube(targetPos, new Vector3(width, height, 0.1f));

        Gizmos.DrawWireSphere(transform.position, centerRadius);

    }

    public float GetZoom()
    {
        return cameraZoom;
    }

    public Vector3 GetCenterPos()
    {
        return new Vector3(center.transform.position.x, center.transform.position.y, -10);
    }
}
