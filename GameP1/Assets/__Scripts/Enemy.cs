using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3;
    public float maxRange = 8f;
    public float minRange = 0.5f;
    public int health = 20;
    public GameObject drop;

    void Start()
    {
        //Gets the player's position
        target = Player.instance.player.transform;
    }
    
    public virtual void Update()
    {
        //If the player exists and is within the view range, the enemy will move towards the player
        if ((target != null) && (Vector3.Distance(target.position, transform.position) <= maxRange) && (Vector3.Distance(target.position, transform.position) >= minRange))
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        //Takes the player and enemy position and makes the enemy take a straight path towards the player
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //On collision with the player, the player takes damage or dies
        if(collision.collider.tag == "Player")
        {
            Player.instance.health = Player.instance.health - 5;
            if(Player.instance.health <= 0)
            {
                Player.instance.Respawn();
            }
        }
    }
}