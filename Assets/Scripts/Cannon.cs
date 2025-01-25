using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Vector3 MousePos;
    public Camera MainCam;
    public GameObject Bullet;
    public Transform BulletTransform;
    public bool CanFire;
    private float FireTimer;
    public float TimeBetweenFiring = 2.0f;

    void Update()
    {
        MousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        //MousePos = Input.mousePosition;
        Vector3 rotation = MousePos - transform.position;
        float RotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, RotZ);

        if (!CanFire)
        {
            FireTimer += Time.deltaTime;
            if (FireTimer > TimeBetweenFiring)
            {
                CanFire = true;
                FireTimer = 0;
            }
        }
        if (Input.GetMouseButton(0) && CanFire == true)
        {
            CanFire = false;
            Instantiate(Bullet, BulletTransform.position, Quaternion.identity);
        }
    }
}
