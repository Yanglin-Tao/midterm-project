using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator Animator;
    GameManager _gameManager;
    public AudioClip deathSound;
    AudioSource _audioSource;

    void Start(){
        Animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            if (_gameManager.getScore() >= 1 && _gameManager.getSword()){
                Animator.SetBool("Death", true);
                _audioSource.PlayOneShot(deathSound);
                _gameManager.setEnemyKilled(true);
                StartCoroutine(Death(2));
            }
        }
    }

    IEnumerator Death (int seconds) {
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
