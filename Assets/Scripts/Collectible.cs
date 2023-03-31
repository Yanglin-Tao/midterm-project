using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    int speed = 10;
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    // public AudioClip collectSound;
    public int score = 1;
    // AudioSource _audioSource;

    void Start()
    {
        speed = Random.Range(5, 20);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, -speed));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        // _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Boundary")){
            Destroy(gameObject);
        }

        // if(other.CompareTag("Player")){
        //     _audioSource.PlayOneShot(collectSound);
        //     Destroy(gameObject);
        //     _gameManager.AddScore(score);
        // }
    }
}