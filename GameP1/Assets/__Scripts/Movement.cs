using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    private float dashCoolDown = 0.5f;
    private float nextDashTime = 0;
    private float dashEndTime = -1;
    private int speed = 4;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime * speed;

        if(Time.time > dashEndTime)
        {
            speed = 4;

        }
        if (Input.GetKeyDown("space"))
        {
            if (Time.time > nextDashTime)
            {
                dashEndTime = Time.time + 0.01f;
                speed = 100;
                nextDashTime = Time.time + dashCoolDown;
            }
        }
        if (Input.GetKey("1"))
        {
            if (Player.instance.currentWeapons[0] == true)
            {
                Player.instance.activeWeapon = 0;
            }
        }
        if (Input.GetKey("2"))
        {
            if (Player.instance.currentWeapons[1] == true)
            {
                Player.instance.activeWeapon = 1;
            }
        }
        if (Input.GetKey("3"))
        {
            if (Player.instance.currentWeapons[2] == true)
            {
                Player.instance.activeWeapon = 2;
            }
        }
        if (Input.GetKey("4"))
        {
            if (Player.instance.currentWeapons[3] == true)
            {
                Player.instance.activeWeapon = 3;
            }
        }
    }
}
