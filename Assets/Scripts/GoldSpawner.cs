using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] PickupPrefabs;
    public float targetTime;


    void Spawner()
    {

        {
            var position = new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f));
            Instantiate(prefab, position, Quaternion.identity);

        }

    }

    void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            Spawner();
            targetTime = Random.Range(3, 6);
        }
    }
}
