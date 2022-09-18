using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScoreManager : MonoBehaviour
{

    [SerializeField] Text EndScoreText;
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;
    public int Endscore;

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
        EndScoreText.gameObject.SetActive(state == GameManager.GameState.End);
        restartButton.gameObject.SetActive(state == GameManager.GameState.End);
        quitButton.gameObject.SetActive(state == GameManager.GameState.End);
     
    }

    // Update is called once per frame
    void Update()
    {
        EndScoreText.text = "End score: " + Endscore.ToString();
    }

    public void RestartGame()
    {
        GameManager.instance.UpdateGameState(GameManager.GameState.Restart);
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

}
