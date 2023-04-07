using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void loadLevel1(){
        SceneManager.LoadScene("Level0.5");
    }
    public void loadLevel2(){
        SceneManager.LoadScene("Level1.5");
    }
    public void loadLevel3(){
        SceneManager.LoadScene("Level2.5");
    }
    public void loadLevel4(){
        SceneManager.LoadScene("Level3.5");
    }
}
