using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraMovement : MonoBehaviour
{

    public GameObject cameraObj;
    public GameObject deathField;
    public GameObject playerCharacter;
    public Vector2 pastPosition;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerCharacter.transform.position.y > cameraObj.transform.position.y)
        {
            cameraObj.transform.position = new Vector3(0, playerCharacter.transform.position.y, -10);
            deathField.transform.position = new Vector3(0, playerCharacter.transform.position.y - 11f, -10);
            if (playerCharacter.transform.position.y > pastPosition.y)
            {
                pastPosition = playerCharacter.transform.position;
            }
        }
        if (pastPosition.y > playerCharacter.transform.position.y)
        {
            int intPos = (int)pastPosition.y;
            scoreText.text = ("Score: " + intPos.ToString());
            scoreTextDeath.text = ("Score: " + intPos.ToString());
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            deathField.transform.position = new Vector3(0f, playerCharacter.transform.position.y - 11f, -10f);
        }
    }
}