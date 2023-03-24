using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    int speed = 10;
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    public int score = 1;

    void Start()
    {
        speed = Random.Range(5, 20);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, -speed));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Boundary")){
            Destroy(gameObject);
        }

        if(other.CompareTag("Player")){
            _gameManager.AddScore(score);
        }
    }
}