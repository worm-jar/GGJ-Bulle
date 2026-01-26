using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject fish;
    public static bool CheckpointSpawned;
    public Vector3 spawnPosition;
    public GameObject playerCharacter;
    public int randomChanceCheckpoint;
    public GameObject checkpoint;
    public Rigidbody2D rb;
    public int Rando;
    public Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = fish.GetComponent<Rigidbody2D>();
        StartCoroutine(wait());
        playerCharacter = GameObject.Find("Player 1");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerCharacter.transform.position;
        randomChanceCheckpoint = Random.Range(1, 3000);
        if (randomChanceCheckpoint == 1 && !CheckpointSpawned)
        {
            spawnPosition.x = Random.Range(-5, 5);
            spawnPosition.y = Random.Range(playerPos.y + 5.5f, playerPos.y + 20);
            Instantiate(checkpoint, spawnPosition, Quaternion.identity);
            CheckpointSpawned = true;
        }
        //int Rando = Random.Range(0, 1);
        //if (Rando == 0)
        //{
        //    instantiate(fish, (15, Random.Range(10, 20)), Quaternion.identity);
        //    rb.velcity = new Vector2(-2.5, -0.2);
        //}  
        //else if (Rando == 1)
        //{
        //    instantiate(fish, (15, Random.Range(-20, 10)), Quaternion.identity);
        //    rb.velcity = new Vector2(2.5, -0.2);
        //}
    }
    public IEnumerator wait()
    {
        while (true)
        {
            Rando = Random.Range(0, 2);
            if (Rando == 0)
            {
                Instantiate(fish, new Vector3(-15f, Random.Range(playerPos.y + 5f, playerPos.y + 15f), 0f), Quaternion.identity);      
            }
            else if (Rando == 1)
            {
                Instantiate(fish, new Vector3(15f, Random.Range(playerPos.y + 5f, playerPos.y + 15f), 0f), Quaternion.identity);
            }
            yield return new WaitForSeconds(1.5f + (Time.deltaTime)/100);
        }
    }
}
