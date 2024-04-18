using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{

    private GameObject PauseFilm;
    private bool isPaused = false;
    private CharController charControllerInstance;
    private GameObject enemy;
    private Image cButton;

    public void Start(){
        charControllerInstance = FindObjectOfType<CharController>();
        PauseFilm = GameObject.Find("PauseFilm");
        PauseFilm.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        enemy = GameObject.Find("Tutorial_Wasp");
        cButton = GameObject.Find("Click").GetComponent<Image>();
    }
    public void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)&& !isPaused && charControllerInstance.isDead == false){
            pause();
        }else if(Input.GetKeyDown(KeyCode.Escape)&& isPaused){
            resume();
        }
        
        if(enemy == null){
            cButton.enabled = false;
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
        charControllerInstance.isDead = false; // Set the variable
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
