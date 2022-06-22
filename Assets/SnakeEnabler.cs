using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnabler : MonoBehaviour
{
    [SerializeField] public GameObject snake;

    private void OnEnable()
    {
        snake.gameObject.SetActive(true);
        snake.gameObject.transform.parent = transform;
        GameManager.instance.UpdateGameState(GameManager.GameState.GameLoop);
    }

    public void resetSnakePos() { snake.gameObject.transform.position = new Vector3(0, 0, 0); }
            
      
}
