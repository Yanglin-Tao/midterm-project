using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string restartLevel;

    public void RestartLevel(){
        // restartLevel = _gameManager.getCurrentLevel();
        SceneManager.LoadScene(restartLevel);
    }

    public void PlayGame(){
        SceneManager.LoadScene("Level0.5");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
