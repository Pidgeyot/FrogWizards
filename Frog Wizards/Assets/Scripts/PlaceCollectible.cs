using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCollectible : MonoBehaviour
{
    private int currentCollectibles = 0;
    // Start is called before the first frame update
    [Header("Collectible Models")]
    public GameObject[] collectibles = new GameObject[5]; // Create an array of size 5

    void Start()
    {    

    }

    // Update is called once per frame
    void Update()
    {
        if(currentCollectibles < 10){
            placeCollectibles(collectibles, randomLocationGenerator());
        } 
    }
    public Vector3 randomLocationGenerator()
    {
        float minX = -10f;
        float maxX = 10f;
        float minY = 0f;
        float maxY = 5f;
        float minZ = -10f;
        float maxZ = 10f;

        Vector3 randomLocation = new Vector3();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);
        randomLocation = new Vector3(randomX, randomY, randomZ);
        
        //Debug.Log("Random Location: " + randomLocation);
        
        return randomLocation;
    }

    public void placeCollectibles(GameObject[] collectibles, Vector3 coords){
        //place (random collectible) at randomLocationGenerator();
        if (currentCollectibles < 10)
        {
            // Use Random.Range(0, 5) to get a random index between 0 and 4.
            int randomIndex = Random.Range(0, 5);
            Debug.Log("Collectibles array length: " + collectibles.Length);
            GameObject collectibleToPlace = collectibles[randomIndex];
            GameObject collectibleNew = Instantiate(collectibleToPlace, coords, Quaternion.identity) as GameObject;
            Debug.Log(collectibleNew);
            collectibleNew.transform.parent = gameObject.transform;
            currentCollectibles++;
            Debug.Log(currentCollectibles);
        }
    }
}

   
    
    
