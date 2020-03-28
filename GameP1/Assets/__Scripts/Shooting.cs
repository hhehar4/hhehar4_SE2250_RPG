using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //Controls the player's shooting technique

    public GameObject[] projectilePrefabs;
    public GameObject spawnPoint;
    public float projectileForce = 20f;
    private int[] projectileSpeeds = {350, 150, 500};

    // Update is called once per frame
    void Update()
    {
        //Checks if the right mouse button is pressed to shoot the level specified projectiles
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot(Player.instance.level);
        }
    }

    void Shoot(int tracker)
    {
        //Gets the mouse position on click
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, -0.2f));
        clickPosition.z = -0.2f;

        //Creates a projectile on the player
        GameObject projectile = Instantiate(projectilePrefabs[tracker], spawnPoint.transform.position, spawnPoint.transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        //Gets the vector to the target location with respect to the player's position
        clickPosition.x = clickPosition.x - spawnPoint.transform.position.x;
        clickPosition.y = clickPosition.y - spawnPoint.transform.position.y;

        //Makes the projectile move in the direction of the vector
        rb.AddForce(clickPosition.normalized * projectileSpeeds[tracker]);
    }
}
