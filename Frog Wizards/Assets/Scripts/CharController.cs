using UnityEngine;
using System.Collections;
 
public class CharController : MonoBehaviour {
    public CharacterController charControl;
    public Transform cam;
    public float speed = 10;
    public float turnSmooth = 0.1f;
    float turnSmoothVel;
    public float jumpForce = 10;
    float vSpeed = 0;
    float gravity = 9.8f;
    //bool isGrounded;
    Vector3 moveDir;
    void Start(){
    }

    void Update(){
        Move();
        //Jump();
        //lmb: meleeAttack()
        //rmb: magicAttack()

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
}