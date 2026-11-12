using UnityEngine;

public class PlayerGrappleIndicator : MonoBehaviour
{
    [SerializeField] SwingController swingScript;
    private float maxDistance;
    private Transform transform;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //swingScript = GetComponent<SwingController>();
        maxDistance = swingScript.getMaxHookDistance();
        transform = GetComponent<Transform>();
        if (transform != null)
            transform.localScale = new Vector3(maxDistance * 2, maxDistance * 2, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        colorChange();
    }

    private void colorChange()
    {
        if (swingScript.isNearHook())
            spriteRenderer.color = new Color32(82, 167, 138, 107);
        else
            spriteRenderer.color = new Color32(82, 105, 138, 107);
    }
}
