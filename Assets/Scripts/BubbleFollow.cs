using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = target.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            target = other.gameObject;
        }
        if (other.CompareTag("Death"))
        {
            Destroy(this.gameObject);
        }
    }
}
