using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Vector2 respawnPoint;
    public GameObject deathPos;
    public GameObject cameraObj;

    // Start is called before the first frame update
    void Start()
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
            respawnPoint = new Vector2(other.transform.position.x, other.transform.position.y + 3);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            deathPos.transform.position = new Vector3(0f, respawnPoint.y - 11f, -10f);
            this.gameObject.transform.position = respawnPoint;
            cameraObj.transform.position = new Vector3(0f, respawnPoint.y, -10f);
            if (this.gameObject.layer == 0)
            {
                PlayerInfo.health--;
            }
        }
    }
}
