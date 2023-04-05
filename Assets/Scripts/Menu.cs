using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Level0.5");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
