using UnityEngine;
using UnityEngine.UI;
public class MastermindManager : MonoBehaviour
{
    public int colorCount = 9;
    public int codeLength = 4;
    public int numAttempts = 8;
    private int currentRow = 0;
    private int[] secretCode;
    private int attemptsUsed;
    private bool gameOver = false;
    private bool gameWon = false;
    [SerializeField] private Color[] possibleColors;
    private Button_Mastermind[] buttons;


    public Color correctColor = Color.green;
    public Color misplacedColor = Color.yellow;

    public void Start()
    {
        puzzleStart();
    }
    public void Awake()
    {
        Button_Mastermind.manager = this;
        buttons = new Button_Mastermind[32];
        GameObject PuzzleContent = gameObject;
        for (int i = 0; i < PuzzleContent.transform.childCount; i++)
        {
            buttons[i] = PuzzleContent.transform.GetChild(i).GetComponent<Button_Mastermind>();
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].setActive(i / codeLength == 0);
        }
    }
    public void puzzleStart()
    {
        secretCode = new int[codeLength];
        for (int i = 0; i < codeLength; i++)
        {
            secretCode[i] = Random.Range(0, colorCount);
        }
        attemptsUsed = 0;
        gameOver = false;
    }
    //Guess gets submitted, and also most counters get incremented
    public void submitGuess(int[] guess)
    {
        if (gameOver)
        {
            return;
        }
        int exactCount = 0;
        int[] secretRemaining = new int[colorCount];
        int[] guessRemaining = new int[colorCount];

        //Counts how many are exactly right
        for(int i = 0; i < codeLength; i++)
        {
            if (guess[i] == secretCode[i])
            {
                exactCount++;
                buttons[currentRow * codeLength + i].setOutline(correctColor);
            } else
            {
                secretRemaining[secretCode[i]]++;
                guessRemaining[guess[i]]++;
            }
        }
        //Counts how many are right but in the wrong place
        int misplaced = 0;

        for (int i = 0; i < codeLength; i++)
        {
            if (guess[i] != secretCode[i])
            {
                int color = guess[i];
                if (secretRemaining[color] > 0)
                {
                    misplaced++;
                    secretRemaining[color]--;
                    buttons[currentRow * codeLength + i].setOutline(misplacedColor);
                }
            }
        }

        attemptsUsed++;

        if (exactCount == codeLength)
        {
            gameWon = true;
            gameOver = true;
            endPuzzle();
            return;
        }

        if (attemptsUsed >= numAttempts)
        {
            gameOver = true;
            endPuzzle();
            return;
        }
    }

    //gets colors
    public Color[] getPossibleColors()
    {
        return possibleColors;
    }

    //sets the next row active
    public void nextRow()
    {
        currentRow++;

        if (currentRow >= numAttempts)
        {
            gameOver = true;
            return;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].setActive(i / codeLength == currentRow);
        }
        for (int i = 0; i < codeLength; i++)
        {
            buttons[currentRow * codeLength + i].GetComponent<Image>().color = possibleColors[0];
        }
    }

    //runs through and makes an array to be plugged into the submitGuess function
    public void submitCurrentGuess()
    {
        if (gameOver)
        {
            return;
        }
        int[] guess = new int[codeLength];
        for (int i = 0; i < codeLength; i++)
        {
            guess[i] = buttons[currentRow * codeLength + i].getCurrentColor();
        }
        submitGuess(guess);

        if (!gameOver)
        {
            nextRow();
        }
    }

    public void endPuzzle()
    {
        gameOver = true;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].setActive(false);
        }
        if (gameWon)
        {
            Debug.Log("Game won");
        } else
        {
            Debug.Log("Game lost");
        }
    }
}
