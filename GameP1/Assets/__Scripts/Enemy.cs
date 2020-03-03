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

    void Start()
    {
        target = Player.instance.player.transform;
    }
    
    void Update()
    {
        if ((target != null) && (Vector3.Distance(target.position, transform.position) <= maxRange) && (Vector3.Distance(target.position, transform.position) >= minRange))
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Player.instance.health = Player.instance.health - 5;
            //Debug.Log(Player.instance.health);
            if(Player.instance.health <= 0)
            {
                Destroy(collision.gameObject);
                target = null;
            }
        }
    }

}