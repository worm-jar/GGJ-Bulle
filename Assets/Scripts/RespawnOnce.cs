using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnce : MonoBehaviour
{
    public GameObject respawnFish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.tag = "Untagged";
    }
}
