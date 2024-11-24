using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Drive : MonoBehaviour
{
    public float speed = 5.0f;
    private float currentSpeed;
    public float rotationSpeed = 200.0f;

    public bool allowShoot = false;
    public float bulletCount = 0f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * currentSpeed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);


        if (Input.GetKeyDown(KeyCode.Mouse0) && allowShoot && bulletCount>0)
        {
            bulletCount--;
            ShootBullet();
        }

    }

    public IEnumerator SpeedBoost(float duration, float multiplier)
    {
        currentSpeed = speed * multiplier;
        yield return new WaitForSeconds(duration);
        currentSpeed = speed;
    }

    public IEnumerator AllowShooting(float duration, float count)
    {
        allowShoot = true;
        bulletCount = count;
        yield return new WaitForSeconds(duration);
        allowShoot = false;
        bulletCount = 0f;
    }

    //public void Shooting(float duration, float bulletCount, float bulletSpeed, float bulletLifetime)
    //{
    //    int i = 0;
    //    Debug.Log("Shooting Script started");
    //    if (Input.GetKeyDown(KeyCode.Mouse0) && allowShoot)
    //    {
    //        ShootBullet(bulletSpeed, bulletLifetime);
    //    }
    //}

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = bulletSpawnPoint.forward * 10;
        }

        Destroy(bullet, 5);
    }

}
