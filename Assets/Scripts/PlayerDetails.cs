using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDetails : MonoBehaviour
{

    public bool Invincible;
    public Rigidbody2D rb;
    float shake = 0f;
    float shakeAmount = 10f;
    float decreaseFactor = 1.0f;
    public Camera cameraObj; 
    public AudioSource _aud;
    public AudioClip _clip;
    public AudioClip _clip0;
    public AudioClip _clip1;
    public Animator _animator = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {

            PlayerInfo.health--;
            _aud.clip = _clip;
            _aud.Play();
            rb.velocity = new Vector2(this.gameObject.transform.position.x - collision.gameObject.transform.position.x, 8.0f);
            NoDamage();
        }
        if (collision.gameObject.CompareTag("Bubble"))
            {
            _aud.clip = _clip0;
            _aud.Play();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            _aud.clip = _clip1;
            _aud.Play();
            NoDamage();
        }

    }
    void NoDamage()
    {
        _animator.SetBool("Invincible", true);
        TurnOffSprite.On = true;
        this.gameObject.layer = LayerMask.NameToLayer("Invincible");
        StartCoroutine(BackToDefault());
    }
    IEnumerator BackToDefault()
    {
        yield return new WaitForSeconds(1.8f);
        _animator.SetBool("Invincible", false);
        TurnOffSprite.On = false;
        this.gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
