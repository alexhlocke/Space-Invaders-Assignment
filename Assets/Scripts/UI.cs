using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject highScoreText;
    public GameObject livesText;

    private int score = 0;
    private int highScore = 0;
    private int lives = 3;


    private void Awake() {
        //highScore = PlayerPrefs.GetInt("Highscore", 0);
    }

    public void addToScore(int amount)
    {
        score += amount;
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score.ToString("D4");
    }

    public void addLife()
    {
        lives++;
        livesText.GetComponent<TMPro.TextMeshProUGUI>().text = "Lives: " + lives.ToString("D4");
    }

    public void minusLife()
    {
        lives--;
        if (lives <= 0)
        {
            gameOver();
        }
        livesText.GetComponent<TMPro.TextMeshProUGUI>().text = "Lives: " + lives.ToString("D4");
    }

    public void gameOver()
    {
        FindObjectOfType<AudioManager>().playSound("gameOver");
        Debug.Log("---GAME OVER---");
        if (score > highScore) {
            highScore = score;
            highScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "High Score: " + highScore.ToString("D4");
            PlayerPrefs.SetInt("Highscore", highScore);
        }

        SceneManager.LoadScene("Credits");
        // score = 0;
        // scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score.ToString("D4");
        // lives = 3;
        // livesText.GetComponent<TMPro.TextMeshProUGUI>().text = "Lives: " + lives.ToString("D4");


        //FindObjectOfType<InvaderManager>().resetGame();
    }
}
