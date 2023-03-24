using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectPrefab;

    IEnumerator Start()
    {
        for (int i = 0; i < 2000; i++) {
            Vector2 spawnPos = new Vector2(Random.Range(-15f, 15f), Random.Range(10, 20));
            Instantiate(collectPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(.8f);
        }
    }

}
