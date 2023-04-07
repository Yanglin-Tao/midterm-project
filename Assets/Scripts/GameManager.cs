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
    private bool hasSword = false;
    // private bool spawn = false;
    private bool enemyKilled = false;

    // public void PauseGame ()
    // {
    //     Time.timeScale = 0;
    // }
    // public void ResumeGame ()
    // {
    //     Time.timeScale = 1;
    // }

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        levelName = scene.name;
    }

    // public string getCurrentLevel(){
    //     return levelName;
    // }

    void Start()
    {
        // PauseGame();
        scoreUI.text = "SCORE: " + score;
        lifeUI.text = "HEALTH: " + life;
    }

    // public void setSpawn(bool flag){
    //     spawn = flag;
    // }

    // public bool getSpawn(){
    //     return spawn;
    // }

    public void NextScene(string name){
        print("This ran");

        StartCoroutine(Next(5, name));
    }

    public void setEnemyKilled(bool flag){
        enemyKilled = flag;
    }

    public void minusScore(){
        if (score > 0){
            score -= 1;
        }
        scoreUI.text = "SCORE: " + score;
    }

    public float getHealth(){
        return life;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        scoreUI.text = "SCORE: " + score;
    }

    public void MinusLife(int amount)
    {
        if (life > 0)
        {
            life -= amount;
            if (life <= 0){
                GameOver = true;
                life = 0;
            }
            lifeUI.text = "HEALTH: " + life;
        }
    }

    public void AddLife(int amount)
    {
        if (life > 0)
        {
            life += amount;
            lifeUI.text = "HEALTH: " + life;
        }
    }

    public int getScore(){
        return score;
    }

    public int getLife(){
        return life;
    }

    public bool getSword(){
        return hasSword;
    }

    public void setSword(bool flag){
        hasSword = flag;
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
        if (score >= 10 && enemyKilled)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Level1.5");
        }
        }
    if (levelName == "Level2")
        {
            // This value is intended to be 100
            // For entering Level3
            // 1. get to 10 score
            // 2. get to 5 and step on the boss
        if (score >= 10 && enemyKilled)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Level2.5");
        }
        }

    if (levelName == "Level3")
        {
            // This value is intended to be 100
            // For entering Level4
            // 1. get to 10 score
            // 2. get to the final portal
        if (score >= 10 && enemyKilled)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Level3.5");
        }
        }
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
        if (levelName == "Level4")
        {
            if (score >= 10 && enemyKilled){
                StartCoroutine(swapToEnd(6));
            }
        }
        if (GameOver){
            StartCoroutine(swapToLost(6));
            GameOver = false;
        }
        screenChecker();
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
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
        if (levelName == "Level1"){
            SceneManager.LoadScene("FailEnd1");
        }
        else if (levelName == "Level2"){
            SceneManager.LoadScene("FailEnd2");
        }
        else if (levelName == "Level3"){
            SceneManager.LoadScene("FailEnd3");
        }
        else if (levelName == "Level4"){
            SceneManager.LoadScene("FailEnd4");
        }
    }
    IEnumerator Next(int seconds, string level) {
        int counter = seconds;
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(level);
    }
}
