using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Vector3 MousePos;
    public Camera MainCam;
    void Awake()
    {
        MainCam = GetComponent<Camera>();
    }
    
    void Update()
    {
        MousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        //MousePos = Input.mousePosition;
        Vector3 rotation = MousePos - transform.position;
        float RotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, RotZ);
    }
}
