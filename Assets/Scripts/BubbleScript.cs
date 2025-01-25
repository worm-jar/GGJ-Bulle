using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private Vector3 MousePos;
    public Camera MainCam;
    private Rigidbody2D _rb;
    public GameObject player;
    public Vector3 direction;
    public Collider2D _col;
    
    public float force = 5;

    public GameObject BouncyBubble;

    public void Update()
    {
        
    }
    void Start()
    {
        
        MousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        direction = MousePos - player.transform.position;
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector3(direction.x, direction.y).normalized * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            _col = collision.gameObject.GetComponent<Collider2D>();
            _col.isTrigger = true;
            Instantiate(BouncyBubble, collision.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            
        }
        else if(collision.gameObject.CompareTag("Wall1")|| collision.gameObject.CompareTag("Wall0"))
        {
            Destroy(this.gameObject);
        }
    }
}
