using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 5;

    //if not in range of player
        //wander around within a range of ____
    //when player is in range
        //follow around
        //attack the player if close enough

      void Update(){
        if(health == 0){
            //run dying anim
            Destroy(gameObject);
        }
      }
      public void hit(){
        health --;
      }
}
