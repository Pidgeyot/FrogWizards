using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private bool inCollision = false;
    private PlaceCollectibles placeCollectibles;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        placeCollectibles = GameObject.Find("Environment").GetComponent<PlaceCollectibles>();
        inventory = GameObject.Find("Character").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    { 
      if(inCollision && (Input.GetKeyDown(KeyCode.E))){
        placeCollectibles.currentCollectibles--;
        inventory.addItem(this.gameObject);
        Destroy(this.gameObject);
      }
    }

    private void OnTriggerEnter(Collider collider)
    {
       if (collider.gameObject.tag == "Player"){
        inCollision = true;
        //display collection to player
       }    
    }

    private void OnTriggerExit(Collider collider)
    {
    if (collider.gameObject.tag == "Player"){
        inCollision = false;
        //stop collection display
       } 
    }

}
