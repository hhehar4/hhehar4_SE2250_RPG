using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
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
        if ((target != null) && (Vector3.Distance(target.position, transform.position) <= maxRange))
        {
            if((Time.time > nextDashAttack) && (chargeCounter < 50))
            {
                if(chargeCounter == 48)
                {
                    dashLocation = target.position;
                }
                chargeCounter++;
            }
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
            else if(Time.time > nextShotTime)
            {
                ShootAttack();
            }
        }
    }

    private void ShootAttack()
    {
        nextShotTime = Time.time + 0.5f;
        GameObject projectile = Instantiate(projSprite, transform.position, transform.rotation);
        Vector3 shootLocation = new Vector3(target.position.x - transform.position.x, target.position.y - transform.position.y, 0);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(shootLocation.normalized * 800);
    }

    void DashAttack(Vector3 dashLocation)
    {
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