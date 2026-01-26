using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSprite : MonoBehaviour
{
    public static bool On = false;
    public SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = this.gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (On == true)
        {
            _renderer.enabled = false;
        }
        if (On == false)
        {
            _renderer.enabled = true;
        }
    }
}
