using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject[] projectilePrefabs;
    public GameObject spawnPoint;
    public float projectileForce = 20f;
    private int[] projectileSpeeds = {350, 150, 500};

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot(Player.instance.level);
        }
    }

    void Shoot(int tracker)
    {
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, -0.2f));
        clickPosition.z = -0.2f;

        GameObject projectile = Instantiate(projectilePrefabs[tracker], spawnPoint.transform.position, spawnPoint.transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        clickPosition.x = clickPosition.x - spawnPoint.transform.position.x;
        clickPosition.y = clickPosition.y - spawnPoint.transform.position.y;

        rb.AddForce(clickPosition.normalized * projectileSpeeds[tracker]);
    }
}
