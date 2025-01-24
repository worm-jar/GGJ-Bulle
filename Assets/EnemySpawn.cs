using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject fish;
    public static int fishCount = 9;
    public static bool CheckpointSpawned;
    public Vector3 spawnPosition;
    public GameObject playerCharacter;
    public int randomChanceCheckpoint;
    public GameObject checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (fishCount > 0) 
        {
            spawnPosition.x = Random.Range(-10, 10);
            spawnPosition.y = Random.Range(playerCharacter.transform.position.y + 5.5f, playerCharacter.transform.position.y + 20);
            Instantiate(fish, spawnPosition, Quaternion.identity);
            fishCount--;
        }
        randomChanceCheckpoint = Random.Range(1, 1000);
        if (randomChanceCheckpoint == 1 && !CheckpointSpawned)
        {
            spawnPosition.x = Random.Range(-5, 5);
            spawnPosition.y = Random.Range(playerCharacter.transform.position.y + 5.5f, playerCharacter.transform.position.y + 20);
            Instantiate(checkpoint, spawnPosition, Quaternion.identity);
            CheckpointSpawned = true;
        }
    }
}
