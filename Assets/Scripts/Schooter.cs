using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schooter : MonoBehaviour
{
    
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private float bulletSpeed = 10f;
    [SerializeField]
    private GameObject smoke;
    [SerializeField]
    private AudioSource GunShot;

    // Start is called before the first frame update
    void Start()
    {
        GunShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        //if(OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) // als je de trigger ingedrukt houd
        {
            shoot();
            GunShot.Play();
            GameObject smokeEffect = Instantiate<GameObject>(smoke, transform.position, transform.rotation);
        }

    }

    void shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Create a new bullet instance at the bulletSpawnPoint's position and rotation
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Get the Rigidbody component of the bullet
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                // Set the bullet's velocity based on the pistol's rotation
                bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
            }
            else
            {
                Debug.LogError("Bullet prefab does not have a Rigidbody component.");
            }
        }
        else
        {
            Debug.LogError("Bullet prefab or bullet spawn point not assigned.");
        }
    }
}
