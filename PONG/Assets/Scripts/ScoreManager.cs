using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public TextMeshProUGUI winText;

    public GameObject ball;

    private int player1Score = 0;
    private int player2Score = 0;
    public int winningScore = 5;

    void Start()
    {
        UpdateScoreUI();
        winText.text = "";
    }

    public void AddScore(int player) 
    {
        if (player == 1)
        {
            player1Score++;
        }
        else if (player == 2)
        {
            player2Score++;
        }

        UpdateScoreUI();
        CheckWinCondition();
    }

    void UpdateScoreUI()
    {
        player1Text.text = player1Score.ToString();
        player2Text.text = player2Score.ToString();
    }

    void CheckWinCondition()
    {
        if (player1Score >= winningScore)
        {
            EndGame("Player 1 Wins!");
        }
        else if (player2Score >= winningScore)
        {
            EndGame("Player 2 Wins!");
        }
    }

    void EndGame(string message)
    {
        winText.text = message;
        ball.SetActive(false); // stop the ball

    }
}
