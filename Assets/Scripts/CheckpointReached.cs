using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointReached : MonoBehaviour
{
    public GameObject CheckStop;
    public AudioSource _aud;
    public AudioClip _clip;
    // Start is called before the first frame update
    void Start()
    {
        _aud = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Respawn"))
        {
            Instantiate(CheckStop, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 3.0f), Quaternion.identity);
            _aud.clip = _clip;
            _aud.Play();
        }
    }
}
