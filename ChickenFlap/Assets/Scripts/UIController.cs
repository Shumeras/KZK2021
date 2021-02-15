using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{

    [SerializeField] private Text playerSurvivedTimeText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private GameObject gameOverScreen;

    private float playerSurvivedTime;
    private float highScore;

    public float HighScore 
    { 
        get => highScore; 
        set
        {
            highScore = value; 
            highScoreText.text = $"High Score: {highScore}";
        }    
    }

    public float PlayerSurvivedTime
    {
        get => playerSurvivedTime;
        set
        {
            playerSurvivedTime = value;
            playerSurvivedTimeText.text = $"Survived: {playerSurvivedTime}";
        }
    }

    private void Awake()
    {
        GameController.Instance.gameEndedEvent += OnGameEnded;
        Camera.main.backgroundColor = FindObjectOfType<DataHolder>().data.color;
    }

    private void Start()
    {
        gameOverScreen.SetActive(false);
        PlayerSurvivedTime = 0f;
    }

    void OnGameEnded()
    {
        gameOverScreen.SetActive(true);
    }


}
