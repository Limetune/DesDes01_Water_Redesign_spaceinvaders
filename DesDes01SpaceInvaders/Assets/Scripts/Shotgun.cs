using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shotgun : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    public int pelletCount = 5;
    public float spreadAngle = 30;
    public float fireRate = 1;
    
    public float nextFireTime = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && Time.time >= nextFireTime)
        {
            shoot();
            nextFireTime = Time.time + 1 / fireRate;
        }
    }

    void shoot()
    {
        for(int i = 0; i < pelletCount; math.ispow2(i++))
        {
            float angle = Random.Range(-spreadAngle / 2, spreadAngle / 2);
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Vector2 direction = rotation * firePoint.up;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDirection(direction);
        }
    }
}
