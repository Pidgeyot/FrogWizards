using UnityEngine;
using System.Collections;
using UnityEngine.UI;

 
public class CharController : MonoBehaviour {
    public CharacterController charControl;
    public Transform cam;
    public Transform frogPos;
    public GameObject projectile;
    public float speed = 10;
    public float turnSmooth = 0.1f;
    float turnSmoothVel;
    public float jumpForce = 10;
    float vSpeed = 0;
    float gravity = 9.8f;
    //bool isGrounded;
    Vector3 moveDir;
    public int health = 11;
    public int maxHealth = 11;
    private Image healthSprite;
    

    void Start(){
        healthSprite = GameObject.Find("HealthSprite").GetComponent<Image>();
        Debug.Log(healthSprite);
    }

    void Update(){
        Move();
        if(Input.GetMouseButtonDown(0)) LMBAttack();
        if(Input.GetMouseButtonDown(1)) RMBAttack();
        CheckHealth();
    }

    private void Move(){
        float hMove = Input.GetAxis("Horizontal"); //take in horizontal
        float vMove = Input.GetAxis("Vertical"); //and vertical axis' 

        
        Vector3 move = new Vector3(hMove, 0f, vMove).normalized;
        float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,ref turnSmoothVel, turnSmooth);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //Vector3
        moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        if (charControl.isGrounded){
            // grounded character has vSpeed = 0...
            vSpeed = 0;
            if (Input.GetKeyDown("space")){ // unless it jumps:
            vSpeed = jumpForce;
            }
        }else{
             // apply gravity acceleration to vertical speed:
            vSpeed -= gravity * Time.deltaTime;
            moveDir.y = vSpeed; // include vertical speed in vel
        }

        if (hMove != 0|| vMove != 0 || vSpeed != 0){
        charControl.Move(speed * Time.deltaTime * moveDir.normalized); //use this transform to Move
        }  
    }

    private void LMBAttack(){
        Instantiate(projectile, frogPos.position + new Vector3(0, 0.5f, 0.5f), Quaternion.identity);
    }

    private void RMBAttack(){
        Debug.Log("RMB Attack");
    }

    private void CheckHealth(){
        healthSprite.sprite = Resources.Load<Sprite>("Health" + health);
    }

    public int removeHealth(int damage){
        health -= damage;
        return health;
    }
}