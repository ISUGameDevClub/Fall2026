using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteRotator : MonoBehaviour, IPointerClickHandler
{
    [Header("Click Settings")]
    [SerializeField] private bool rotateOnClick = true;
    [SerializeField] private float rotationAngleStep = 90f;
    [SerializeField] private bool clockwise = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (rotateOnClick)
        {
            RotateSprite();
        }
    }

    public void RotateSprite()
    {
        float direction = clockwise ? -1f : 1f;
        float targetZAngle = transform.eulerAngles.z + (rotationAngleStep * direction);

        transform.rotation = Quaternion.Euler(0f, 0f, targetZAngle);
    }
}
