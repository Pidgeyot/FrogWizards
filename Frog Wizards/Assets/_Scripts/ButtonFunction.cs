using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public void newGame(){
        SceneManager.LoadScene("Scene_1");
        //clear session values
    }
    public void continueGame(){
        SceneManager.LoadScene("Scene_1");
        //keep session values
    }
    public void exit(){
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
