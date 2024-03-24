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

    void Start(){
      charTarget = GameObject.Find("CharRange");
      targetCollider = charTarget.GetComponent<Collider>();
      attackTarget = GameObject.Find("FrogModel");
      attackCollider = attackTarget.GetComponent<BoxCollider>();
      charController = GameObject.Find("Character").GetComponent<CharController>();
      animator = GetComponent<Animator>();
    }

    void Update(){
      if(health == 0){
            animator.Play("Death");
            Wait(); //TODO: make this work
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
      animator.SetBool("Walking", false);
    }

    private void FollowPlayer()
    {
      animator.SetBool("Walking", true);
      // Move towards the player
      Vector3 direction = charTarget.transform.position - transform.position;
      direction.y = 0; // Set y component to 0

      transform.Translate(direction.normalized * 2 * Time.deltaTime, Space.World);
      
      if (direction != Vector3.zero) // Avoid LookAt when direction is zero to prevent erratic behavior
      {
        transform.rotation = Quaternion.LookRotation(direction);
      }

      //check if player is in range to attack
      if (this.GetComponent<Collider>().bounds.Intersects(attackCollider.bounds)) //colliding with player controller collider
      {
        //TODO: stop movement:
        transform.Translate(Vector3.zero);
        AttackPlayer();
      }
    }

    private void AttackPlayer()
    {
      animator.SetTrigger("Attack");
      if (this.GetComponent<Collider>().bounds.Intersects(attackCollider.bounds)) //colliding with player controller collider
        {
          //TODO: implement cooldown on attack; coincide with animation?
          charController.removeHealth(2);        
        }
    }

    public void hit(){
        health --;
    }

    private IEnumerator Wait()
    {
      //didn't work :(
      yield return new WaitWhile(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Death") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
    }
       
}
