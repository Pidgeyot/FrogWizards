using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceEnemies : MonoBehaviour
{
    public int currentEnemies = 0;
    private int maxEnemies = 7;
    // Start is called before the first frame update
    [Header("Enemy Models")]
    public GameObject[] enemies = new GameObject[2]; // Create an array of size 2

    // Update is called once per frame
    void Update()
    {
        if(currentEnemies < maxEnemies){
            placeEnemies(enemies, randomLocationGenerator());
        } 
    }
    public Vector3 randomLocationGenerator()
    {
        float minX = 6f;
        float maxX = 50f;
        float minZ = -15f;
        float maxZ = 36f;

        Vector3 randomLocation = new Vector3();
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        randomLocation = new Vector3(randomX, 0, randomZ);

        return randomLocation;
    }

    public void placeEnemies(GameObject[] enemies, Vector3 coords){
        //place (random enemy) at randomLocationGenerator();
        if (currentEnemies < maxEnemies)
        {
            // Use Random.Range(0, 5) to get a random index between 0 and 4.
            int randomIndex = Random.Range(0, 2);
            GameObject enemyToPlace = enemies[randomIndex];
            GameObject enemyNew = Instantiate(enemyToPlace, coords, Quaternion.identity) as GameObject;
            enemyNew.transform.parent = gameObject.transform;
            currentEnemies++;
            Debug.Log("Current Enemies: " + currentEnemies);
        }
    }
}
