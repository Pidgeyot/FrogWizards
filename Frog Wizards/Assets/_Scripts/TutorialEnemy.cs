using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEnemy : MonoBehaviour
{
    private bool inCollision = false;
    private GameObject enemy;
    private Image cButton;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Tutorial_Wasp");
        cButton = GameObject.Find("Click").GetComponent<Image>();
        cButton.enabled = false;
    }
    void Update(){
        Debug.Log(enemy);
        if(enemy == false){
            inCollision = false;
            cButton.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
       if (collider.gameObject.tag == "CharRange"){
        inCollision = true;
        cButton.enabled = true;
       }    
    }

    private void OnTriggerExit(Collider collider)
    {
    if (collider.gameObject.tag == "CharRange"){
        inCollision = false;
        cButton.enabled = false;
       } 
    }
}
