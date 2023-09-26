using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [Header("Inscribed")]
    public float moveSpeed = 5.0f; // Adjust this to control movement speed
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
         // Check for key presses and set the movement direction
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection = Vector3.back;
        }
        else
        {
            moveDirection.z = 0; // Release W and S keys, stop forward/backward movement
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }
        else
        {
            moveDirection.x = 0; // Release A and D keys, stop left/right movement
        }

        // Normalize the movement vector to ensure consistent speed
        moveDirection.Normalize();
        
        // Move the player
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
