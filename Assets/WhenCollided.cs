using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenCollided : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			FruitSpawner fruitSpawner = FindObjectOfType<FruitSpawner>();
			fruitSpawner.RelocateMe(this.gameObject);
			ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
			scoreKeeper.IncreaseTheScore();
			MoverScript moverScript = FindObjectOfType<MoverScript>();
			moverScript.IncreaseTheSize();
		}
		  
	}


	private void OnDisable()
	{
		if(!this.gameObject.scene.isLoaded) return;

	}

}
