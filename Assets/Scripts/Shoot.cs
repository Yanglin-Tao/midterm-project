using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float maxbulletSpeed = 1f;
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Random.value < fireRate) {
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            // generate a random speed smaller than maxbulletSpeed
            float bulletSpeed = Random.Range(maxbulletSpeed / 2, maxbulletSpeed);
            if (transform.localScale.x < 0) {
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpeed, 0));
            } else {
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
            }
        }
    }
}
