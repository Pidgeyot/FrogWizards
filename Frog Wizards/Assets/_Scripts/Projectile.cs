using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform frogPos;
    private float timer = 0;
    private Enemy enemy;

    void Start(){
        frogPos = GameObject.Find("FrogModel").GetComponent<Transform>();
    }
  
    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = -frogPos.transform.up * 10;
        timer += Time.deltaTime;
        Debug.Log(timer);
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
