using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject player;
    public GameObject BG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BG"))
        {
            Instantiate(BG, new Vector2(0, other.transform.position.y + 43.2f), Quaternion.identity);
        }
    }
}
