using UnityEngine;
using UnityEngine.UI;

public class NewspaperPuzzleManager : MonoBehaviour
{
    [Header("Modal UI")]
    public GameObject puzzleWindow;
    public Button openPuzzleButton;
    public Button closeButton;
    public Button confirmButton;

    [Header("Win Pop-Up")]
    public GameObject winPopupPanel; 
    public Button continueButton;    

    [Header("Newspaper Tiles")]
    public RectTransform[] newspaperTiles;

    private void Start()
    {
        if (puzzleWindow != null)
        {
            puzzleWindow.SetActive(false);
        }

        if (winPopupPanel != null)
        {
            winPopupPanel.SetActive(false);
        }

        
        if (openPuzzleButton != null)
        {
            openPuzzleButton.onClick.AddListener(OpenPuzzle);
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePuzzle);
        }

        if (confirmButton != null)
        {
            confirmButton.onClick.AddListener(CheckSolution);
        }

        if (continueButton != null)
        {
            continueButton.onClick.AddListener(OnContinueClicked);
        }
    }

    public void OpenPuzzle()
    {
        if (puzzleWindow != null)
        {
            puzzleWindow.SetActive(true);
        }

        if (winPopupPanel != null)
        {
            winPopupPanel.SetActive(false);
        }

        RandomizeTiles();
    }

    public void ClosePuzzle()
    {
        if (puzzleWindow != null)
        {
            puzzleWindow.SetActive(false);
        }
    }

    public void RandomizeTiles()
    {
        foreach (RectTransform tile in newspaperTiles)
        {
            if (tile != null)
            {
                int randomStep = Random.Range(0, 4);
                float zAngle = randomStep * 90f;

                tile.localEulerAngles = new Vector3(0f, 0f, zAngle);
            }
        }
    }

    public void CheckSolution()
    {
        for (int i = 0; i < newspaperTiles.Length; i++)
        {
            RectTransform tile = newspaperTiles[i];
            if (tile != null)
            {
                
                float z = tile.localEulerAngles.z % 360f;
                if (z < 0f) z += 360f;

                
                bool isUpright = (z <= 5f || z >= 355f);

                if (!isUpright)
                {
                    Debug.Log($"Tile {tile.name} is NOT upright! Current Z angle: {z}");
                    return;
                }
            }
        }

        Debug.Log("All tiles upright! Opening WinPopupPanel...");
        OnPuzzleSolved();
    }

    private void OnPuzzleSolved()
    {
        
        if (winPopupPanel != null)
        {
            winPopupPanel.SetActive(true);
        }

        if (confirmButton != null)
        {
            confirmButton.interactable = false;
        }

        if (openPuzzleButton != null)
        {
            openPuzzleButton.interactable = false;
        }
    }

    public void OnContinueClicked()
    {
        if (winPopupPanel != null)
        {
            winPopupPanel.SetActive(false);
        }

        ClosePuzzle();
    }

    private void OnDestroy()
    {
        if (openPuzzleButton != null)
        {
            openPuzzleButton.onClick.RemoveListener(OpenPuzzle);
        }

        if (closeButton != null)
        {
            closeButton.onClick.RemoveListener(ClosePuzzle);
        }

        if (confirmButton != null)
        {
            confirmButton.onClick.RemoveListener(CheckSolution);
        }

        if (continueButton != null)
        {
            continueButton.onClick.RemoveListener(OnContinueClicked);
        }
    }
}
