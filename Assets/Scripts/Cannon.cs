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

    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Rotate cannon towards the mouse position
        MousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = MousePos - transform.position;
        float RotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, RotZ);

        // Handle firing cooldown
        if (!CanFire)
        {
            FireTimer += Time.deltaTime;
            if (FireTimer > TimeBetweenFiring)
            {
                CanFire = true;
                FireTimer = 0;
                _animator.SetBool("IsShooting", false); // Reset animation after cooldown
            }
        }

        // Shooting logic
        if (Input.GetMouseButtonDown(0) && CanFire)
        {
            CanFire = false;
            Instantiate(Bullet, BulletTransform.position, Quaternion.identity);
            _animator.SetBool("IsShooting", true); // Trigger shooting animation
        }

        // Stop shooting animation when the mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("IsShooting", false);
        }
    }
}
