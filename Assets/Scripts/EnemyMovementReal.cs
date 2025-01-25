using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementReal : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool right;
    public bool check;
    public SpriteRenderer _sprite;
    // Start is called before the first frame update
    void Start()
    {
        check = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();
        Destroy(this.gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {

        if (check == false)
        {
            float direction = 0 - this.gameObject.transform.position.x;
            if (direction < 0)
            {
                right = false;
                check = true;
            }
            else
            {
                right = true;
                check = true;
            }
        }
        if (right == false)
        {
            rb.velocity = new Vector2(-2.3f, -0.8f);
        }
        else if (right == true)
        {
            rb.velocity = new Vector2(2.3f, -0.8f);
            _sprite.flipX = true;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fish")||other.gameObject.CompareTag("Respawn")|| other.gameObject.CompareTag("Untagged"))
        {
            _sprite.flipX = true;
            rb.velocity = new Vector2(-rb.velocity.x, -0.8f);
        }
    }
}
