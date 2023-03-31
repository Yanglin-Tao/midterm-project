using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectPrefab;
    public GameManager _gameManager;
    private bool spawned = false;

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
            Vector2 spawnPos = new Vector2(Random.Range(-30f, 300f), Random.Range(10, 15));
            Instantiate(collectPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(.2f);
        }
        
    }

}
