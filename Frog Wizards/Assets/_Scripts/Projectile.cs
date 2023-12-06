using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timer = 0;
  
    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 10;
        timer += Time.deltaTime;
        if (timer > 5){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy"){
            Debug.Log("damage goes here");
            //do __ damage to enemy 
        } 
     Destroy(this.gameObject);
    }

}
