using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Animator Animator;
    GameManager _gameManager;

    void Start(){
        Animator = GetComponent<Animator>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            if (_gameManager.getScore() >= 1){
                Animator.SetBool("Death", true);
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
