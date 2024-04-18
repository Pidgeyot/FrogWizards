using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform frogPos;
    private float timer = 0;
    private Enemy enemy;

    void Start(){
        frogPos = GameObject.Find("ProjectileSpawn").GetComponent<Transform>();
        this.gameObject.GetComponent<Rigidbody>().velocity = -frogPos.transform.forward * 10; 
    }
  
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy"){
            enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.hit();
        } 
     Destroy(this.gameObject);
    }

}
