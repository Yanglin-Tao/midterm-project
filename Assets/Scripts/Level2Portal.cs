using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Portal : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // keep rotating itself
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            GameManager _gameManager = GameObject.FindObjectOfType<GameManager>();
            SceneManager.LoadScene("Level3");
        }
    }
}
