using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private static int _score;
    public static int Score { get { return _score; } }
    [SerializeField] Text scoreText;
    
    void Start()
    {
        GameManager.OnGameStateChanged += GameManagerGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerGameStateChanged;  
    }

    private void GameManagerGameStateChanged(GameManager.GameState state)
    {
        scoreText.gameObject.SetActive(state == GameManager.GameState.GameLoop);
        if (state == GameManager.GameState.End)
        {
            ResetTheScore();
        }
    }

    
    void Update()
    {
        
        scoreText.text = "Score: " + _score.ToString();
    }

    private void ResetTheScore()
    {
        _score = 0;
    }

    public void IncreaseTheScore()
    {
        _score++;
    }

    public static int EndScore()
    {
        return Score;
    }

}
