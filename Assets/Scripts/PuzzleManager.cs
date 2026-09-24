using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [Header("Modal UI")]
    [SerializeField] private GameObject puzzlePanel;
    [SerializeField] private GameObject openPuzzleButton;
    [SerializeField] private Selectable firstSelected;

    [Header("Gameplay")]
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private string puzzleActionMap;
    [SerializeField] private bool pauseGameplay = true;

    private float previousTimeScale = 1f;
    private string previousActionMap;

    public bool IsOpen => puzzlePanel != null && puzzlePanel.activeSelf;

    private void Awake()
    {
        if (puzzlePanel != null)
        {
            puzzlePanel.SetActive(false);
        }
    }

    public void OpenPuzzle()
    {
        if (puzzlePanel == null || IsOpen)
        {
            return;
        }

        previousTimeScale = Time.timeScale;
        previousActionMap = playerInput != null ? playerInput.currentActionMap?.name : null;

        if (pauseGameplay)
        {
            Time.timeScale = 0f;
        }

        if (playerInput != null && !string.IsNullOrWhiteSpace(puzzleActionMap))
        {
            playerInput.SwitchCurrentActionMap(puzzleActionMap);
        }

        puzzlePanel.SetActive(true);

        if (openPuzzleButton != null)
        {
            openPuzzleButton.SetActive(false);
        }

        if (EventSystem.current != null && firstSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(firstSelected.gameObject);
        }
    }

    public void ClosePuzzle()
    {
        if (!IsOpen)
        {
            return;
        }

        puzzlePanel.SetActive(false);

        if (openPuzzleButton != null)
        {
            openPuzzleButton.SetActive(true);
        }

        if (pauseGameplay)
        {
            Time.timeScale = previousTimeScale;
        }

        if (playerInput != null && !string.IsNullOrWhiteSpace(previousActionMap))
        {
            playerInput.SwitchCurrentActionMap(previousActionMap);
        }

        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void TogglePuzzle()
    {
        if (IsOpen)
        {
            ClosePuzzle();
        }
        else
        {
            OpenPuzzle();
        }
    }
}
