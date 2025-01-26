using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraMovement : MonoBehaviour
{

    public GameObject camera;
    public GameObject deathField;
    public GameObject playerCharacter;
    public Vector2 pastPosition;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerCharacter.transform.position.y > camera.transform.position.y)
        {
            camera.transform.position = new Vector3(0, playerCharacter.transform.position.y, -10);
            deathField.transform.position = new Vector3(0, playerCharacter.transform.position.y - 8f, -10);
            pastPosition = playerCharacter.transform.position;
        }
        if (pastPosition.y > playerCharacter.transform.position.y)
        {
            int intPos = (int)pastPosition.y;
            scoreText.text = ("Score: " + intPos.ToString());
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            deathField.transform.position = new Vector3(0f, playerCharacter.transform.position.y - 8f, -10f);
        }
    }
}