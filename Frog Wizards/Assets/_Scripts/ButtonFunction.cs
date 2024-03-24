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
        PlayerPrefs.SetInt("BellflowerCount", 0);
        PlayerPrefs.SetInt("BluebellCount", 0);
        PlayerPrefs.SetInt("FlyAgaricCount", 0);
        PlayerPrefs.SetInt("IndigoMushroomCount", 0);
        PlayerPrefs.SetInt("PeriwinkleCount", 0);
    }
    public void continueGame(){
        SceneManager.LoadScene("Scene_1");
    }
    public void exit(){
        Application.Quit();
    }
    public void pause(){
        PauseFilm.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void resume(){
        PauseFilm.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void loadMenu(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void retry(){
        CharController charControllerInstance = FindObjectOfType<CharController>(); // Find an instance of CharController
        charControllerInstance.isDead = false; // Set the variable
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
