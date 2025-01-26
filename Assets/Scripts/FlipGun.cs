using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGun : MonoBehaviour
{
    private Vector3 MousePos;
    private Vector3 _vector;
    public Camera MainCam;
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        float direction = MousePos.x - this.gameObject.transform.position.x;
        if (direction < 0 && check == false)
        {
            _vector = transform.localScale;
            _vector.y *= -1;
            transform.localScale = _vector;
            check = true;

        }
        if (direction >= 0 && check == true)
        {
            _vector = transform.localScale;
            _vector.y *= -1;
            transform.localScale = _vector;
            check = false;
        }
    }
}
