using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenCollided : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
		  
	}

	private void OnDisable()
	{
		if(!this.gameObject.scene.isLoaded) return;
		FruitSpawner fruitSpawner = FindObjectOfType<FruitSpawner>();
		fruitSpawner.SpawnANewFruit();
		ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
		scoreKeeper.Score++;
		MoverScript moverScript = FindObjectOfType<MoverScript>();
		moverScript.IncreaseTheSize();
	}

}
