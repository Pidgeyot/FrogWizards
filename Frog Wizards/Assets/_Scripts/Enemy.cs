using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 5;

    void Update(){
    
      if(health == 0){
            //run dying anim
            Destroy(gameObject);
      }else if (InRangeOfPlayer())
      {
        FollowPlayer();
      }
      else
      {
        Wander();
      }
    }

    private bool InRangeOfPlayer()
    {
      // If enemy collider is in contact with player sphere
      // Return true if in range, false otherwise
      return false;
    }

    private void Wander()
    {
      // Implement wandering behavior within a specified range
      //move in a small circle around point of origin
    }

    private void FollowPlayer()
    {
      //move towards the player
       if (true) //colliding with player controller collider
        {
          AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
      //run attack anim
      //if collliding with player/close enough
      //deal damage to player
    }

    public void hit(){
        health --;
    }
       
}
