using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4 : MonoBehaviour
{

    public float speed = 6;
    public float jumpForce = 300;

    public LayerMask ground;
    bool isGrounded = false;
    public Transform feet;

    private Rigidbody2D rb;
    private Animator Animator;
    private Collider2D _collider2D;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void FixedUpdate() {

        float xSpeed = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);

        float xScale = transform.localScale.x;
        if ((xSpeed < 0 && xScale >0) || (xSpeed > 0 && xScale < 1)){
            // get current localScale
            Vector3 localScale = transform.localScale;
            // flip x axis
            transform.localScale = new Vector3(-xScale, localScale.y, localScale.z);
        }

        Animator.SetFloat("Speed", Mathf.Abs(xSpeed));

    }

    void Update(){

        isGrounded = Physics2D.OverlapCircle(feet.position, .2f, ground);
        Animator.SetBool("Grounded", isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded){
            rb.AddForce(new Vector2(0, jumpForce));
        }

        // player dies if he falls off the map
        if (transform.position.y < -10){
            Destroy(gameObject);
        }
    }


}
