using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCollectibles : MonoBehaviour
{
    public int currentCollectibles = 0;
    private int maxCollectibles = 50;
    // Start is called before the first frame update
    [Header("Collectible Models")]
    public GameObject[] collectibles = new GameObject[5]; // Create an array of size 5

    // Update is called once per frame
    void Update()
    {
        if(currentCollectibles < maxCollectibles){
            placeCollectibles(collectibles, randomLocationGenerator());
        } 
    }
    public Vector3 randomLocationGenerator()
    {
        float minX = -237f;
        float maxX = -75f;
        float minZ = -50f;
        float maxZ = 67f;

        Vector3 randomLocation = new Vector3();
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        randomLocation = new Vector3(randomX, 0, randomZ);

        return randomLocation;
    }

    public void placeCollectibles(GameObject[] collectibles, Vector3 coords){
        //place (random collectible) at randomLocationGenerator();
        if (currentCollectibles < maxCollectibles)
        {
            // Use Random.Range(0, 5) to get a random index between 0 and 4.
            int randomIndex = Random.Range(0, 5);
            GameObject collectibleToPlace = collectibles[randomIndex];
            GameObject collectibleNew = Instantiate(collectibleToPlace, coords, Quaternion.identity) as GameObject;
            collectibleNew.transform.parent = gameObject.transform;
            currentCollectibles++;
        }
    }
}
