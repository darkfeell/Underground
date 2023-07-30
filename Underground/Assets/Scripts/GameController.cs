using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public TMPro.TextMeshProUGUI healthText;
    public int totalScore;

    public int score;
    public TMPro.TextMeshProUGUI scoreText;

    public GameObject pause;
    private bool isPaused;
    public GameObject over;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        totalScore = PlayerPrefs.GetInt("score");
    }

    private void Update()
    {
        pauseGame();    
    }

    // Update is called once per frame
    public void updateLives(int value)
    {
        healthText.text = "x" + value.ToString();
    }

    public void updateScore(int value)
    {
        score += value;
        scoreText.text = "x" + score.ToString();

        PlayerPrefs.SetInt("score", score + totalScore);
    }

    public void pauseGame()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pause.SetActive(isPaused);
        }
        if(isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        over.SetActive(true);
        Time.timeScale = 0f;
    }

    public void restart()
    {
        //player.play.transform.position = player.play.respawnPoint;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //public void LoadNextScene()
    //{
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //}
}
