using UnityEngine;

public class ShootingBullet: MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint; 
    public float bulletSpeed = 100.0f; 
    public float bulletLifetime = 5.0f;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        Destroy(bullet, bulletLifetime);
    }
}

public class Bullet : MonoBehaviour
{
    public float slowEffectDuration = 3.0f; 
    public float speedReductionFactor = 0.5f; 

    private void OnTriggerEnter(Collider other)
    {
        Player_Drive targetCar = other.GetComponent<Player_Drive>();
        if (targetCar != null)
        {
            StartCoroutine(SlowDown(targetCar));
        }

        Destroy(gameObject);
    }

    private System.Collections.IEnumerator SlowDown(Player_Drive targetCar)
    {
        float originalSpeed = targetCar.speed;
        targetCar.speed *= speedReductionFactor;
        yield return new WaitForSeconds(slowEffectDuration);
        targetCar.speed = originalSpeed;
    }

    private System.Collections.IEnumerator SlowDownAI(RacingAI aiCar)
    {
        float originalSpeed = aiCar.agent.speed;
        aiCar.agent.speed *= speedReductionFactor;
        yield return new WaitForSeconds(slowEffectDuration);

        float elapsedTime = 0.0f;
        while (elapsedTime < slowEffectDuration)
        {
            aiCar.agent.speed = Mathf.Lerp(originalSpeed * speedReductionFactor, originalSpeed, elapsedTime / slowEffectDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        aiCar.agent.speed = originalSpeed;
    }
}
