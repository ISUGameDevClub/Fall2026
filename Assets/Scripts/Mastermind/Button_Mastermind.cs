using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Button_Mastermind : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] InputActionReference Mastermind;
    bool active = false;
    int state = 0;
    private int currentColor = 0;
    public static MastermindManager manager;
    private Color[] colors;
    int[] activeRow = new int[4];

    public void Start()
    {
        colors = manager.getPossibleColors();
        if (active)
        {
            GetComponent<Image>().color = colors[0];
        }
        else
        {
            GetComponent<Image>().color = Color.white;
        }
    }

    public void OnClick()
    {
        if (active)
        {
            currentColor++;
            if (currentColor >= colors.Length)
            {
                currentColor = 0;
            }
            GetComponent<Image>().color = colors[currentColor];
        }
    }

    public void OnRightClick()
    {
        if (active)
        {
            currentColor--;
            if (currentColor < 0)
            {
                currentColor = colors.Length - 1;
            }
            GetComponent<Image>().color = colors[currentColor];
        }
    }
    public void setActive(bool value)
    {
        active = value;
    }

    public int getCurrentColor()
    {
        return currentColor;
    }

    public void setOutline(Color color)
    {
        GetComponent<Outline>().effectColor = color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

}
