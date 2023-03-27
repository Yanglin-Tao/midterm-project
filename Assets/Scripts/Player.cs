using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 6;
    public float jumpForce = 300;

    public LayerMask ground;
    bool isGrounded = false;
    public Transform feet;

    private Rigidbody2D rb;
    private Animator Animator;
    private Collider2D _collider2D;
    GameManager _gameManager;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void FixedUpdate() {

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


    void Update(){

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("this ran");
        if (collision.gameObject.tag == "Bully")
        {
            _gameManager.MinusLife(3);
        }
        if (collision.gameObject.tag == "Tomato"){
            _gameManager.MinusLife(1);
        }
        if (collision.gameObject.tag == "spike"){
            _gameManager.MinusLife(3);
        }

        // if (collision .gameObject.tag == "ground"){
        //     print("this ran");
        //     isGrounded = true;
        // }
    }


}
