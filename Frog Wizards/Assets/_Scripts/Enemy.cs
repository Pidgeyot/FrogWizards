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
    private Animator animator;
    private bool isAttacking = false;
    private bool attackAvailable  = true;
    private bool isDead = false;
    private PlaceEnemies placeEnemies;

    void Start(){
      charTarget = GameObject.Find("CharRange");
      targetCollider = charTarget.GetComponent<Collider>();
      attackTarget = GameObject.Find("FrogModel");
      attackCollider = attackTarget.GetComponent<BoxCollider>();
      charController = GameObject.Find("Character").GetComponent<CharController>();
      animator = GetComponent<Animator>();
      placeEnemies = GameObject.Find("Environment").GetComponent<PlaceEnemies>();
    }

    void Update(){
      if(health == 0){
            isDead = true;
            animator.Play("Death");
            StartCoroutine(WaitDeath()); //TODO: make this work
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
      animator.SetBool("Walking", false);
    }

    private void Move()
    {
      animator.SetBool("Walking", true);
      if (this.GetComponent<Collider>().bounds.Intersects(attackCollider.bounds)) //colliding with player controller collider
      {
        isAttacking = true;
      }

      if(!isAttacking && !isDead){
        // Move towards the player
        Vector3 direction = charTarget.transform.position - transform.position;
        direction.y = 0; // Set y component to 0
        transform.Translate(direction.normalized * 2 * Time.deltaTime, Space.World);
      
        if (direction != Vector3.zero) // Avoid LookAt when direction is zero to prevent erratic behavior
        {
          transform.rotation = Quaternion.LookRotation(direction);
        }
      }
    }

    private void FollowPlayer()
    {
      Move();
      //check if player is in range to attack
      if (isAttacking && attackAvailable == true && !isDead) //colliding with player controller collider
      {
        attackAvailable = false;
        isAttacking = false;
        transform.Translate(Vector3.zero);
        animator.SetTrigger("Attack");
        StartCoroutine(WaitAttack());
      }
      
    }

    private IEnumerator WaitAttack()
    {
      yield return new WaitForSeconds(2);
      AttackPlayer();
      animator.ResetTrigger("Attack");
      attackAvailable = true;
    }

    private IEnumerator WaitDeath()
    {
      yield return new WaitForSeconds(2);
      Destroy(gameObject);
      placeEnemies.currentEnemies--;
    }
    
    private void AttackPlayer()
    {
      if (this.GetComponent<Collider>().bounds.Intersects(attackCollider.bounds)) //colliding with player controller collider
        {
          charController.removeHealth(2);        
        }
    }

    public void hit(){
        health --;
    }
       
}
