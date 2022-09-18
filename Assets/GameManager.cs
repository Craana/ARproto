using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        instance = this;    
    }

    private void Start()
    {
        UpdateGameState(GameState.Start);
    }

    public void UpdateGameState(GameState newstate)
    {
        State = newstate;

        switch (newstate)
        {
            case GameState.Start:
                HandleStart();
                break;
            case GameState.GameLoop:
                HandleGameloop();
                break;
            case GameState.End:
                HandleEndgame();
                break;
            case GameState.Restart:
                HandleRestart();
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newstate);
    }

    public void HandleRestart()
    {
        Debug.Log("RESTART");
        //Reset position for the snake, get rid of the body, spawn fruits, reset score and change the state for GameLoopGameState.
        MoverScript ms = FindObjectOfType<MoverScript>();
        ms.DeleteEveryBodyPart();
        ms.ResetThePosition();
        HealthScript hs = FindObjectOfType<HealthScript>();
        hs.ResetHealth();
        UpdateGameState(GameState.GameLoop);
    }

    private void HandleEndgame()
    {
        //Take the score, show it middle of the screen. Spawn a button where player can restart the game.
        Debug.Log("END");
    }

    private void HandleGameloop()
    {
        Debug.Log("GAME LOOP");
    }

    private void HandleStart()
    {
        Debug.Log("START");
    }

    public enum GameState
    {
        Start,
        GameLoop,
        End,
        Restart
    }
}
