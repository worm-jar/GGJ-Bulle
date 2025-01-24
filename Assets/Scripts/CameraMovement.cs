using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject camera;
    public GameObject playerCharacter;
    public Rigidbody2D rb;
    public Vector2 pastPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = playerCharacter.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y >= 0)
            {
            camera.transform.position = new Vector3(0, playerCharacter.transform.position.y, -10f);
            pastPosition = playerCharacter.transform.position;
            }
        else
            {
            camera.transform.position = new Vector3(0, pastPosition.y, -10f);
            }
        
    }
}
