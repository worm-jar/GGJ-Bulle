using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Vector2 respawnPoint;
    public Transform deathPos;
    public Transform camera;
    public GameObject fish;

    // Start is called before the first frame update
    void start()
    {
        respawnPoint = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            respawnPoint = new Vector2(other.transform.position.x, other.transform.position.y + 1);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
        deathPos.position = new Vector2(respawnPoint.x, respawnPoint.y - 5f);
        camera.position = new Vector2(respawnPoint.x, respawnPoint.y);
        this.gameObject.transform.position = respawnPoint;
            fish = GameObject.Find("Fish");
            Destroy(fish);
        }
    }
}
