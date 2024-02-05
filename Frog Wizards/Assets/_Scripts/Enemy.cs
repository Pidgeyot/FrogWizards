using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 5;
    private GameObject charTarget;
    private Collider targetCollider;
    private GameObject attackTarget;
    private Collider attackCollider;
    private CharController charController;
    void Start(){
      charTarget = GameObject.Find("CharRange");
      targetCollider = charTarget.GetComponent<Collider>();
      attackTarget = GameObject.Find("FrogModel");
      attackCollider = attackTarget.GetComponent<Collider>();
      charController = GameObject.Find("Character").GetComponent<CharController>();
    }

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
      if(this.GetComponent<Collider>().bounds.Intersects(targetCollider.bounds))
      {
        return true;
      }
       return false;
    }

    private void Wander()
    {
      // Implement wandering behavior within a specified range
      //move in a small circle around point of origin
    }

    private void FollowPlayer()
    {
      // Move towards the player
      Vector3 direction = charTarget.transform.position - transform.position;
      transform.Translate(direction.normalized * 2 * Time.deltaTime);
      
      //check if player is in range to attack
      if (this.GetComponent<Collider>().bounds.Intersects(attackCollider.bounds)) //colliding with player controller collider
      {
        Debug.Log("Player in range to attack");
        AttackPlayer();
      }
    }

    private void AttackPlayer()
    {
      //run attack anim
      if (this.GetComponent<Collider>().bounds.Intersects(attackCollider.bounds)) //colliding with player controller collider
        {
          Debug.Log("Attacking player");
          charController.removeHealth(2);        
        }
    }

    public void hit(){
        health --;
    }
       
}
