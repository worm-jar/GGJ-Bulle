using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource _aud;
    public AudioClip _clip0;
    public AudioClip _clip1;
    public AudioClip _clip2;
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MusicWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInfo.health <= 0 && check == false)
        {
            _aud.loop = false;
            _aud.clip = _clip2;
            _aud.Play();
            check = true;
        }
    }
    public IEnumerator MusicWait()
    {
        _aud.clip = _clip0;
        _aud.Play();
        yield return new WaitForSeconds(3f);
        _aud.clip = _clip1;
        _aud.Play();
        _aud.loop = true;
    }
}
