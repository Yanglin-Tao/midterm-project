using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectPrefab;
    public GameManager _gameManager;
    private bool spawned = false;
    public float minSpawnPositionX = -30f;
    public float maxSpawnPositionX = 300f;


    void Start(){
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update(){
        if (_gameManager.getSpawn() && !spawned){
            StartCoroutine(StartSpawn());
            spawned = true;
        }
    }

    IEnumerator StartSpawn()
    {
        for (int i = 0; i < 4000; i++) {
            Vector2 spawnPos = new Vector2(Random.Range(minSpawnPositionX, maxSpawnPositionX), Random.Range(15, 20));
            Instantiate(collectPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(.2f);
        }
        
    }

}
