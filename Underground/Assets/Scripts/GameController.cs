using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public TMPro.TextMeshProUGUI healthText;
    

    public int score;
    public TMPro.TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
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
    }
}
