using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 6;
    public float jumpForce = 300;

    public LayerMask ground;
    bool isGrounded = false;
    bool flag = true;
    public Transform feet;

    private Rigidbody2D rb;
    private Animator Animator;
    private Collider2D _collider2D;
    public GameObject explosion;
    GameManager _gameManager;

    private bool hasSword = false;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void FixedUpdate() {

        if (_gameManager.getHealth() != 0){
            float xSpeed = Input.GetAxis("Horizontal") * speed;
            rb.velocity = new Vector2(xSpeed, rb.velocity.y);

            float xScale = transform.localScale.x;
            if ((xSpeed < 0 && xScale > 0) || (xSpeed > 0 && xScale < 1)){
                // get current localScale
                Vector3 localScale = transform.localScale;
                // flip x axis
                transform.localScale = new Vector3(-xScale, localScale.y, localScale.z);
            }
            Animator.SetFloat("Speed", Mathf.Abs(xSpeed));
        }
        Animator.SetFloat("Health", _gameManager.getHealth());
    }


    void Update(){
        if (_gameManager.getHealth() != 0){
            isGrounded = Physics2D.OverlapCircle(feet.position, .2f, ground);
            if (Input.GetButtonDown("Jump") && isGrounded){
                rb.AddForce(new Vector2(0, jumpForce));
                Animator.SetBool("Jump", !isGrounded);
            }
            Animator.SetBool("Jump", !isGrounded);

            // player dies if he falls off the map
            if (transform.position.y < -10){
                Destroy(gameObject);
            }
        }
        else{
            StartCoroutine(Death(2));
            // if (flag){
            Instantiate(explosion, transform.position, Quaternion.identity);
            //    flag = false;
            //}
        }
        Animator.SetFloat("Health", _gameManager.getHealth());
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Bully"){
            _gameManager.MinusLife(3);
        }
        if (collision.gameObject.tag == "Tomato"){
            _gameManager.MinusLife(1);
        }
        if (collision.gameObject.tag == "Spike"){
            _gameManager.MinusLife(3);
        }
        if (collision.gameObject.tag == "Sword"){
            hasSword = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Reaper"){
            if (hasSword){
                Animator.SetBool("Attack", true);
            }
            else {
                _gameManager.MinusLife(3);
            }
        }
        
    }

    IEnumerator Death (int seconds) {
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

}
