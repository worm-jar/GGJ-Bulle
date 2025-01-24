using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{

    public GameObject wall0, wall1;
    public GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        wall0.transform.position = new Vector2(-12f, playerCharacter.transform.position.y);
        wall1.transform.position = new Vector2(12f, playerCharacter.transform.position.y);
    }
}
