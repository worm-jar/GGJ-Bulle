using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetails : PlayerInfo
{

    public bool invincible;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            health--;
            rb.velocity = new Vector2(collision.gameObject.transform.position.x - this.gameObject.transform.position.x, 8.0f);
            NoDamage();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            NoDamage();
        }

    }
    public void NoDamage()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Invincible");
        StartCoroutine(BackToDefault());
    }
    public IEnumerator BackToDefault()
    {
        yield return new WaitForSeconds(01.8f);
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
