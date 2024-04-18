using UnityEngine;
using System.Collections;
using UnityEngine.UI;

 
public class CharController : MonoBehaviour {
    public Transform frogPos;
    public Transform projectilePos;
    public GameObject projectile;
    public int health = 11;
    public int maxHealth = 11;
    public bool isDead = false;
    private Image healthSprite;
    private GameObject gameOver;
    

    void Start(){
        healthSprite = GameObject.Find("HealthSprite").GetComponent<Image>();
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
        Debug.Log("Char Start Time.timeScale: " + Time.timeScale);
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)) LMBAttack();
        if(Input.GetMouseButtonDown(1)) RMBAttack();
    }

    void FixedUpdate(){
        LoadHealth();
        CheckGameOver();
    }

    private void LMBAttack(){
        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }

    private void RMBAttack(){
        Debug.Log("RMB Attack");
    }

    private void LoadHealth(){
        if(health > 0){
            healthSprite.sprite = Resources.Load<Sprite>("Health" + health);
        }
    }

    public int removeHealth(int damage){
        health -= damage;
        return health;
    }

    public void CheckGameOver(){
        if(health <= 0 && isDead == false){
            isDead = true;
            halfInventory();
            Time.timeScale = 0;
            gameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void halfInventory(){
        PlayerPrefs.SetInt("BellflowerCount", PlayerPrefs.GetInt("BellflowerCount")/2);
        PlayerPrefs.SetInt("BluebellCount", PlayerPrefs.GetInt("BluebellCount")/2);
        PlayerPrefs.SetInt("FlyAgaricCount", PlayerPrefs.GetInt("FlyAgaricCount")/2);
        PlayerPrefs.SetInt("IndigoMushroomCount", PlayerPrefs.GetInt("IndigoMushroomCount")/2);
        PlayerPrefs.SetInt("PeriwinkleCount", PlayerPrefs.GetInt("PeriwinkleCount")/2);
        PlayerPrefs.Save();
    }
}