using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFalse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Death"))
        {
            EnemySpawn.CheckpointSpawned = false;
            Debug.Log("False");
        }
    }
}
