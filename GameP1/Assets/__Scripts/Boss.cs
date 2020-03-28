using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    //Controls the final boss
    public Transform target;
    public GameObject projSprite;
    public float speed = 10;
    public float maxRange = 20f;
    public int health = 500;
    private float nextDashAttack = 0;
    private float nextShotTime = 2;
    private int chargeCounter = 0;
    private Vector3 dashLocation;
    public GameObject drop;


    void Start()
    {
        //Gets the player's position
        target = Player.instance.player.transform;
    }

    public void FixedUpdate()
    {
        //Checks if player is within range
        if ((target != null) && (Vector3.Distance(target.position, transform.position) <= maxRange))
        {
            //Checks if the dash attack is off cooldown or if it is not fully charged
            if((Time.time > nextDashAttack) && (chargeCounter < 50))
            {
                //Gets the player's position and sets it as the dash location
                if(chargeCounter == 48)
                {
                    dashLocation = target.position;
                }
                chargeCounter++;
            }
            //Makes the boss move towards the saved location very quickly once the charge up is completed
            else if(chargeCounter > 0)
            {
                nextDashAttack = Time.time + 100;
                DashAttack(dashLocation);
                chargeCounter--;
                if(chargeCounter == 0)
                {
                    nextDashAttack = Time.time + 4;
                }
            }
            //If the dash attack is on cooldown, the boos just shoots at the player
            else if(Time.time > nextShotTime)
            {
                ShootAttack();
            }
        }
    }

    private void ShootAttack()
    {
        //Creates a projectile at the boss's position
        nextShotTime = Time.time + 0.5f;
        GameObject projectile = Instantiate(projSprite, transform.position, transform.rotation);
        //Gets a vector going from the boss to the player
        Vector3 shootLocation = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        //Makes the projectile move along the vector
        rb.AddForce(shootLocation.normalized * 800);
    }

    void DashAttack(Vector3 dashLocation)
    {
        //Moves the boss towards the dash location
        transform.position = Vector3.MoveTowards(transform.position, dashLocation, speed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //On collision with the player, the player takes damage or dies
        if (collision.collider.tag == "Player")
        {
            Player.instance.health = Player.instance.health - 15;
            if (Player.instance.health <= 0)
            {
                Player.instance.Respawn();
            }
        }
    }
}