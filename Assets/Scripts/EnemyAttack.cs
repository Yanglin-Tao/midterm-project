using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator Animator;
    GameManager _gameManager;
    public AudioClip attackSound;
    AudioSource _audioSource;

    void Start(){
        Animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Animator.SetBool("Attack", false);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            if (_gameManager.getScore() < 1){
                Animator.SetBool("Attack", true);
                _audioSource.PlayOneShot(attackSound);
            }
        }
    }
}
