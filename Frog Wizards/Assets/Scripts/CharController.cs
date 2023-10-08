using UnityEngine;
using System.Collections;
 
public class CharController : MonoBehaviour {
    public CharacterController charControl;
    public Rigidbody rb;
    public float speed = 10;
    public float jumpForce = 10;
    bool isGrounded;
    void Start(){
    }

    void Update(){
        Move();
        Jump();
        //lmb: meleeAttack()
        //rmb: magicAttack()

    }

    private void Move(){
        float hMove = Input.GetAxis("Horizontal"); //take in horizontal
        float vMove = Input.GetAxis("Vertical"); //and vertical axis' 

        Vector3 move = transform.forward * vMove + transform.right * hMove; //apply them to a transform
        charControl.Move(speed * Time.deltaTime * move); //use this transform to Move
    }

    private void Jump(){
        if(Input.GetKeyDown(KeyCode.Space)) //if space pressed
        {
            Debug.Log("Space pressed");
            rb.AddForce(Vector3.up * jumpForce); //apply upward force to rigidbody
            Debug.Log("added force");
        }
    }

}