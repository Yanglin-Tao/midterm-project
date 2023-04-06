using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealLevel2Boss : MonoBehaviour
{
    private Animator Animator;
    GameManager _gameManager;
    public int neededScore = 10;
    public float speed = 5;
    public float maxXPos = 0;
    public float minXPos = 0;
    public float jumpProbability = 0.1f;
    public float jumpForce = 300;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider2D;
    public Transform feet;
    bool grounded = false;
    public LayerMask WhatIsGround;

    void Start(){
        Animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // move from left to right and back forever
        // if moved for more than move_distance, turn and change direction on just x axis
        _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
        if (transform.position.x > maxXPos)
        {
            speed = -Mathf.Abs(speed);
            // get current localScale
            Vector3 localScale = transform.localScale;
            // flip x axis
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
        else if (transform.position.x < minXPos)
        {
            speed = Mathf.Abs(speed);
            // get current localScale
            Vector3 localScale = transform.localScale;
            // flip x axis
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(feet.position, .3f, WhatIsGround);
        // print(grounded);
        // Randomly jump based on a probability
        if (Random.value < jumpProbability && grounded)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            if (_gameManager.getScore() >= neededScore){
                Destroy(gameObject);
                SceneManager.LoadScene("Level3");
            }
        }
    }
}
