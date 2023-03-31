using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioClip deathSound;
    public AudioClip collectSound;
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
    AudioSource _audioSource;


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
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
        Animator.SetBool("Attack", false);
    }


    void Update(){
        if (_gameManager.getHealth() != 0){
            isGrounded = Physics2D.OverlapCircle(feet.position, .2f, ground);
            if (Input.GetButtonDown("Jump") && isGrounded){
                rb.AddForce(new Vector2(0, jumpForce));
                Animator.SetBool("Jump", !isGrounded);
                _audioSource.PlayOneShot(jumpSound);
            }
            Animator.SetBool("Jump", !isGrounded);

            // player dies if he falls off the map
            if (transform.position.y < -10){
                _gameManager.MinusLife(3);
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
        if (collision.gameObject.tag == "Billman"){
            _gameManager.MinusLife(1);
            _audioSource.PlayOneShot(hitSound);
        }
        if (collision.gameObject.tag == "Level3Boss"){
            _gameManager.MinusLife(1);
            _audioSource.PlayOneShot(hitSound);
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
                if (_gameManager.getScore() < 1){
                    _gameManager.MinusLife(3);
                }
            }
            else {
                _gameManager.MinusLife(3);
            }
        }
        if (collision.gameObject.tag == "Collectible"){
            _audioSource.PlayOneShot(collectSound);
            Destroy(gameObject);
            _gameManager.AddScore(1);
        }

    }

    IEnumerator Death (int seconds) {
        _audioSource.PlayOneShot(deathSound);
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

}
