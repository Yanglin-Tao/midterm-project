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



    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void FixedUpdate() {

        float xSpeed = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
      
        float xScale = transform.localScale.x;
        if ((xSpeed < 0 && xScale >0) || (xSpeed > 0 && xScale < 1)){
            transform.localScale *= new Vector2(-1, 1);
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
    }


}
