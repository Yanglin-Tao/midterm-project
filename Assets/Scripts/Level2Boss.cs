using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Boss : MonoBehaviour
{
    private Animator Animator;
    GameManager _gameManager;
    public float speed = 5;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider2D;

    public AudioClip deathSound;
    AudioSource _audioSource;

    int bulletSpeed = 1000;
    public GameObject bulletPrefab;
    public GameObject explosion;
    public Transform spawnPoint;
    int health;

    void Start(){
        Animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody2D>();
        health = 3;

    }

    void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
    }


    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Pen"){
            Animator.SetBool("canThrow", true);
            speed = -speed;
            bulletSpeed = -bulletSpeed;
            // get current localScale
            Vector3 localScale = transform.localScale;
            // flip x axis
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
            
            GameObject Bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().AddForce(new Vector3(bulletSpeed, 0, 1));
            Animator.SetBool("canThrow", false);
        }

        if (collision.gameObject.tag == "Burger"){
            health -= 1;
            if (health == 0){
                StartCoroutine(Death(2));
            }
        }

    }

    IEnumerator Death (int seconds) {
        _audioSource.PlayOneShot(deathSound);
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
