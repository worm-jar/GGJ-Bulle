using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private Vector3 MousePos;
    public Camera MainCam;
    private Rigidbody2D _rb;
    
    public float force = 5;

    public GameObject BouncyBubble;

    void Start()
    {
        MousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        _rb = GetComponent<Rigidbody2D>();
        Vector3 direction = MousePos - transform.position;
        Vector3 rotation = transform.position - MousePos;
        _rb.velocity = new Vector3(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>())
        {
            Instantiate(BouncyBubble, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            Destroy(this.gameObject);
            
        }
        else if(collision.gameObject.GetComponent<Wall>())
        {
            Destroy(this.gameObject);
        }
    }
}
