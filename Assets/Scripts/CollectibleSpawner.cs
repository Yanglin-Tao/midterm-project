using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectPrefab;

    IEnumerator Start()
    {
        for (int i = 0; i < 4000; i++) {
            Vector2 spawnPos = new Vector2(Random.Range(-30f, 300f), Random.Range(10, 15));
            Instantiate(collectPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(.2f);
        }
    }

}
