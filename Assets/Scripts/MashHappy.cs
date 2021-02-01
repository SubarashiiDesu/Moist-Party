using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MashHappy : MinigameManager
{
    public Text ScoreText1;  // Text to show the score for player 1
    public Text ScoreText2;
    public Text ScoreText3;
    public Text ScoreText4;

    [SerializeField]
    private string player1Button;  // Button for player 1 to mash
    [SerializeField]
    private string player2Button;
    [SerializeField]
    private string player3Button;
    [SerializeField]
    private string player4Button;

    private int player1Score = 0;  // How many times player 1 has mashed
    private int player2Score = 0;  // How many times player 1 has mashed
    private int player3Score = 0;  // How many times player 1 has mashed
    private int player4Score = 0;  // How many times player 1 has mashed



    public override void Update()
    {
        if (phase == "Playing")
        {
            if (Input.GetKeyDown(player1Button))
            {
                player1Score += 1;
            }

            if (Input.GetKeyDown(player2Button))
            {
                player2Score += 1;
            }

            if (Input.GetKeyDown(player3Button))
            {
                player3Score += 1;
            }

            if (Input.GetKeyDown(player4Button))
            {
                player4Score += 1;
            }
        }
    }



    public override IEnumerator GameLoop()
    {
        // Start off by running the 'GameStart'
        yield return StartCoroutine(GameStarting());

        // Once the 'GameStart' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        // Once execution has returned here, run the 'GameEnd' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        yield return StartCoroutine(ShowScores());

        yield return StartCoroutine(ShowResults());

        SceneManager.LoadScene("BoardScene");
    }



    IEnumerator ShowScores()
    {
        ScoreText1.text = "Player 1:\n" + player1Score.ToString();
        ScoreText2.text = "Player 2:\n" + player2Score.ToString();
        ScoreText3.text = "Player 3:\n" + player3Score.ToString();
        ScoreText4.text = "Player 4:\n" + player4Score.ToString();

        yield return new WaitForSeconds(3);
    }



    public override IEnumerator ShowResults()
    {
        ScoreText1.text = "";
        ScoreText2.text = "";
        ScoreText3.text = "";
        ScoreText4.text = "";

        int highest = Mathf.Max(player1Score, player2Score, player3Score, player4Score);

        bool tie = false;
        int winner = 0;

        // Find the player number of the winner
        if (player1Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 1;
            }

            else
            {
                tie = true;
            }
        }

        if (player2Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 2;
            }
            // Otherwise tie
            else
            {
                tie = true;
            }
        }

        if (player3Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 3;
            }

            else
            {
                tie = true;
            }
        }

        if (player4Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 4;
            }

            else
            {
                tie = true;
            }
        }

        if (tie)
        {
            UIMainText.text = "TIE";
        }
        else
        {
            UIMainText.text = "Player " + winner.ToString() + " Wins!";
        }

        yield return resultsWait;
    }
}
