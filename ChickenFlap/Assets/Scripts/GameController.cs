using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    private float highScore;
    private float survivedTime;

    public bool GameHasEnded { get; private set; }
    
    public float SurvivedTime 
    { 
        get => survivedTime; 
        private set
        {
            survivedTime = value;
            UIController.Instance.PlayerSurvivedTime = Mathf.Round(survivedTime);
        }
    }

    public float HighScore
    {
        get => highScore;
        set
        {
            highScore = value;
            UIController.Instance.HighScore = Mathf.Round(highScore);
        }
    }

    public event Action gameEndedEvent;

    private void Awake()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore", 0f);
        gameEndedEvent +=
            () =>
                Debug.Log("Game ended event raised");
    }

    private void Update()
    {

        if (!GameHasEnded)
        {
            SurvivedTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GameEnd()
    {
        Debug.Log("Game Ended");
        if (HighScore < SurvivedTime)
        {
            HighScore = SurvivedTime;
            PlayerPrefs.SetFloat("HighScore", HighScore);
            PlayerPrefs.Save();
        }
        GameHasEnded = true;
        gameEndedEvent.Invoke();

    }

}
