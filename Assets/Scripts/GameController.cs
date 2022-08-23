using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text healthText;

    public int score;
    public Text scoreText;

    public GameObject pauseObj;
    public GameObject gameOverObj;

    public int totalScore;

    public bool isSunny = true;
    public bool isRainy = false;

    public static GameController instance;
    private bool isPaused;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        if (PlayerPrefs.HasKey("score")) {
            totalScore = PlayerPrefs.GetInt("score");
            //scoreText.text = "x " + score.ToString();
        }
    }

    private void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("score"));
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "x " + score.ToString();

        PlayerPrefs.SetInt("score", score + totalScore);
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x " + value.ToString();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                isPaused = true;
                pauseObj.SetActive(true);
                Time.timeScale = 0;
            }
            else if (isPaused)
            {
                isPaused = false;
                pauseObj.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
