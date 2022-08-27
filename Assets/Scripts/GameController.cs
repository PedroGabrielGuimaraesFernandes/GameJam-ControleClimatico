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

    

    //public int totalScore;

    public bool isSunny = true;
    public bool isRainy = false;

    public static GameController instance;
    private bool isPaused;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
       
    }

    private void Start()
    {
        if (isSunny)
        {
            UIController.instance.sunnyAnim.SetInteger("Trasition", 0);
            UIController.instance.rainyAnim.SetInteger("Trasition", 1);
        }
        else if (isRainy)
        {
            UIController.instance.sunnyAnim.SetInteger("Trasition", 1);
            UIController.instance.rainyAnim.SetInteger("Trasition", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
        if (Input.GetKeyDown(KeyCode.E))
        {
        CheckWeather();
        }
    }

    void CheckWeather()
    {
        if (isSunny)
        {
            isSunny = false;
            isRainy = true;
            UIController.instance.sunnyAnim.SetInteger("Trasition", 1);
            UIController.instance.rainyAnim.SetInteger("Trasition", 0);

        }
        else if (isRainy)
        {
            isRainy = false;
            isSunny = true;
            UIController.instance.sunnyAnim.SetInteger("Trasition", 0);
            UIController.instance.rainyAnim.SetInteger("Trasition", 1);
        }

    }

    public void UpdateLives(int value)
    {
        UIController.instance.WriteLives(value);
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                isPaused = true;
                UIController.instance.pauseObj.SetActive(true);
                Time.timeScale = 0;
            }
            else if (isPaused)
            {
                isPaused = false;
                UIController.instance.pauseObj.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void ContinueGame()
    {
        isPaused = false;
        UIController.instance.pauseObj.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        UIController.instance.gameOverObj.SetActive(true);
    }

    public void RestartLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
