using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int Health = 3;
    public int MaxHealth = 3;
    bool hasDied = false;
    // Start is called before the first frame update
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
        if (state == GameManager.GameState.GameLoop)
        {
            hasDied = false;
        }
    
    }

    private void Update()
    {

       if (Health < 0 && hasDied == false)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.End);
            hasDied = true;
        }
    }

    public void ResetHealth()
    {
        Health = 3;
    }

    public void DecreaseHealth()
    {
        Health--;
    }

}
