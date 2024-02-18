using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{

    private GameObject PauseFilm;
    private bool isPaused = false;

    public void Start(){
        PauseFilm = GameObject.Find("PauseFilm");
        PauseFilm.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)&& !isPaused){
            pause();
        }else if(Input.GetKeyDown(KeyCode.Escape)&& isPaused){
            resume();
        }
    }
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
    }
    public void pause(){
        PauseFilm.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }
    public void resume(){
        PauseFilm.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
    public void loadMenu(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
