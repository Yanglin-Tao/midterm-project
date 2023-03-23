using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    int life = 3;
    string levelName;

    public TMPro.TextMeshProUGUI scoreUI;
    public TMPro.TextMeshProUGUI lifeUI;

    private bool GameOver = false;

    private void Awake()
    {   
        Scene scene = SceneManager.GetActiveScene();
        levelName = scene.name;
    }

    void Start()
    {
        scoreUI.text = "SCORE: " + score;
        lifeUI.text = "LIFE: " + life;
    }

    public void AddScore()
    {
        score += 1;
        scoreUI.text = "SCORE: " + score;
    }

    public void MinusLife()
    {
        if (life > 0)
        {
            life -= 1;
            lifeUI.text = "LIFE: " + life;
            if (life == 0){
                GameOver = true;
            }
        }
    }

    public void AddLife()
    {
        if (life > 0)
        {
            life += 1;
            lifeUI.text = "LIFE: " + life;
        }
    }

    public int getScore(){
        return score;
    }

    public int getLife(){
        return life;
    }

    void screenChecker()
    {
#if !UNITY_WEBGL
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif

    if (levelName == "Level1")
        {
        if (score >= 10)
        {
            Destroy(gameObject); 
            SceneManager.LoadScene("Level2");
        }
        }
    if (levelName == "Level2")
        {
        if (score >= 20)
        {
            Destroy(gameObject); 
            SceneManager.LoadScene("Level3");
        }
        }

    if (levelName == "Level3")
        {
        if (score >= 20)
        {
            Destroy(gameObject); 
            SceneManager.LoadScene("Level4");
        }
        }
    }

    void Update(){
        if (levelName == "Level4")
        {
            StartCoroutine(swapToEnd(6));
        }
        if (GameOver){
            StartCoroutine(swapToLost(6));
            GameOver = false;
        }
        screenChecker();
    }

    IEnumerator swapToEnd (int seconds) {
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("SuccessEnd");
    }
    IEnumerator swapToLost (int seconds) {
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        score = 0;
        life = 3;
        SceneManager.LoadScene("FailEnd");
    }
}
