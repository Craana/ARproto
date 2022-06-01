using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnabler : MonoBehaviour
{
    [SerializeField] GameObject snake;

    private void OnEnable()
    {
        snake.gameObject.SetActive(true);
        snake.gameObject.transform.parent = transform;
    }
}
