using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private bool inCollision = false;
    private PlaceCollectibles placeCollectibles;
    // Start is called before the first frame update
    void Start()
    {
        placeCollectibles = GameObject.Find("Environment").GetComponent<PlaceCollectibles>();
    }

    // Update is called once per frame
    void Update()
    { 
      if(inCollision && (Input.GetKeyDown(KeyCode.E))){
        Debug.Log("e key was pressed in collider");
        //increase player count for item 
        Debug.Log("placeCol: " + placeCollectibles);
        placeCollectibles.currentCollectibles--;
        Destroy(this.gameObject);
      }
    }

    private void OnTriggerEnter(Collider collider)
    {
       if (collider.gameObject.tag == "Player"){
        inCollision = true;
        Debug.Log("Collision between player and collectible. inCol: " + inCollision);
        //display collection to player
       }    
    }

    private void OnTriggerExit(Collider collider)
    {
    if (collider.gameObject.tag == "Player"){
        inCollision = false;
        Debug.Log("Collision exit between player and collectible. inCol: " + inCollision);
        //stop collection display
       } 
    }

}
