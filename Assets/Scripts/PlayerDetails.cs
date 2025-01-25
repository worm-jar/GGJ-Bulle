using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{

    public bool invincible;
    public Rigidbody2D rb;
    float shake = 0f;
    float shakeAmount = 10f;
    float decreaseFactor = 1.0f;
    public Camera cameraObj;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {

            PlayerInfo.health--;
            rb.velocity = new Vector2(collision.gameObject.transform.position.x - this.gameObject.transform.position.x, 8.0f);
            NoDamage();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            NoDamage();
        }

    }
    void NoDamage()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Invincible");
        StartCoroutine(BackToDefault());
    }
    IEnumerator BackToDefault()
    {
        yield return new WaitForSeconds(01.8f);
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
