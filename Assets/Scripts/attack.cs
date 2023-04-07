using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    int speed;
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    GameObject[] _Bully;
    // public AudioClip collectSound;
    // AudioSource _audioSource;
    public GameObject explosion;

    void Start()
    {
        speed = Random.Range(5, 20);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(0, -speed));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bully") || other.CompareTag("Pen")){
            if (other.CompareTag("Bully")){
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        // if(other.CompareTag("Player")){

    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
        

        // if(other.CompareTag("Player")){

    }
}