using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject fish;
    public Rigidbody2D rb;
    private int randomDirection;

    // Start is called before the first frame update
    void Awake()
    {
        fish = this.gameObject;
        rb = fish.GetComponent<Rigidbody2D>();
        randomDirection = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (randomDirection == 1)
        {
            rb.velocity = new Vector2(2f, -0.5f);
        }
        else
        {
            rb.velocity = new Vector2(-2f, -0.5f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall1"))
        {
            randomDirection = 0;
        }
        if (collision.gameObject.CompareTag("Wall0"))
        {
            randomDirection = 1;
        }
        if (collision.gameObject.CompareTag("Fish"))
        {
            if (randomDirection == 1)
            {
                randomDirection = 0;
            }
            else
            {
                randomDirection = 1;
            }
        }
    }
}
