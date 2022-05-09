using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] Transform _planeTransform;
    [SerializeField] GameObject _spawnableObject;
    public int amountOfFruits = 5;
    float zPos = 1;
    float xPos = 1;
    Vector3 parentlocalPosition;
    // Start is called before the first frame update
    void OnEnable()
    {
        
        //Plane localtransform is -1 to 1 on both axes.
        for (int i = 0; i <  amountOfFruits; i++)
        {
            var RandomPosition = new Vector3(Random.Range(-xPos, xPos), transform.localPosition.y, Random.Range(-zPos,zPos));
            GameObject tempFruit = Instantiate(_spawnableObject, transform.position + RandomPosition, Quaternion.identity);
            tempFruit.transform.parent = transform;
        }
    }

   public void SpawnANewFruit()
    {

        var RandomPosition = new Vector3(Random.Range(-xPos, xPos), transform.localPosition.y, Random.Range(-zPos, zPos));
        GameObject tempFruit = Instantiate(_spawnableObject, transform.position + RandomPosition, Quaternion.identity);
        tempFruit.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
