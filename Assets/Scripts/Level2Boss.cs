using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Boss : MonoBehaviour
{
    private Animator Animator;
    GameManager _gameManager;
    public int neededScore = 10;
    public float speed = 5;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider2D;

    void Start(){
        Animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
    }


    // void OnTriggerEnter2D(Collider2D other){
    //     if (other.CompareTag("Pen")){
    //         print("Went in here");
    //         speed = -speed;
    //         // get current localScale
    //         Vector3 localScale = transform.localScale;
    //         // flip x axis
    //         transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Pen"){
            print("Went in here");
            speed = -speed;
            // get current localScale
            Vector3 localScale = transform.localScale;
            // flip x axis
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }
}
