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

    // Start is called before the first frame update
    void OnEnable()
    {
        
        //Plane localtransform is -1 to 1 on both axes.
        for (int i = 0; i <  amountOfFruits; i++)
        {
            var RandomPosition = new Vector3(Random.Range(_planeTransform.position.x + -xPos, _planeTransform.position.x + xPos), _planeTransform.position.y, Random.Range(_planeTransform.transform.position.z + -zPos,_planeTransform.position.x + zPos));
            GameObject tempFruit = Instantiate(_spawnableObject, RandomPosition, Quaternion.identity);
            tempFruit.transform.parent = _planeTransform.transform;
        }
    }
    
    public void RelocateMe(GameObject fruit)
    {
        fruit.transform.parent = transform;
        fruit.gameObject.transform.position = new Vector3(Random.Range(_planeTransform.position.x + -xPos,
               _planeTransform.position.x + xPos), _planeTransform.transform.position.y + 0.025f, 
                Random.Range(_planeTransform.position.z + -zPos,_planeTransform.transform.position.z + zPos));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
