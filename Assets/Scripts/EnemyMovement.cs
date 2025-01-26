using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject fish;
    public Rigidbody2D rb;
    public static int direction;
    public Vector3 spawnPosition;
    public GameObject playerCharacter;
    // Start is called before the first frame update
    void Awake()
    {
        fish = this.gameObject;
        rb = fish.GetComponent<Rigidbody2D>();
        direction = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
        {
            rb.velocity = new Vector2(2f, -0.5f);
        }
        else
        {
            rb.velocity = new Vector2(-2f, -0.5f);
        }
        while (EnemySpawn.fishCount > 0)
        {
            if (EnemyMovement.direction == 1)
            {
                spawnPosition.x = 15;
            }
            else
            {
                spawnPosition.x = -15;
            }
            spawnPosition.y = Random.Range(playerCharacter.transform.position.y + 5.5f, playerCharacter.transform.position.y + 10);
            Instantiate(fish, spawnPosition, Quaternion.identity);
            EnemySpawn.fishCount--;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Wall1"))
        //{
        //    randomDirection = 0;
        //}
        //if (collision.gameObject.CompareTag("Wall0"))
        //{
        //    randomDirection = 1;
        //}
        if (collision.gameObject.CompareTag("Fish")||collision.gameObject.CompareTag("Respawn"))
        {
            if (direction == 1)
            {
                direction = 0;
            }
            else
            {
                direction = 1;
            }
        }
    }
}
