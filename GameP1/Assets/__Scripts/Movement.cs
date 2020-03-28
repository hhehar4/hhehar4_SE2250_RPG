using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Controls the player's base movement, dashing, and inventory

    public Animator animator;
    private float dashCoolDown = 0.5f;
    private float nextDashTime = 0;
    private float dashEndTime = -1;
    private int speed = 4;
    private Color activeSlot = new Color(0.4353f, 0.4353f, 0.4353f, 1f);
    private Color inactiveSlot = new Color(0.2157f, 0.2157f, 0.2157f, 1f);

    void Update()
    {
        //Gets the input from the keyboard and animates accordingly
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        transform.position = transform.position + movement * Time.deltaTime * speed;

        //Returns speed of player back to normal after dash
        if(Time.time > dashEndTime)
        {
            speed = 4;
        }
        //If the player presses the space key and if the dash is not on cooldown, it allows the player to dash in the direction of movement
        if (Input.GetKeyDown("space"))
        {
            if (Time.time > nextDashTime)
            {
                dashEndTime = Time.time + 0.01f;
                speed = 100;
                nextDashTime = Time.time + dashCoolDown;
            }
        }
        //Switches weapon to slot 1 if the player has that weapon
        if (Input.GetKey("1"))
        {
            if (Player.instance.currentWeapons[0] == true)
            {
                Player.instance.activeWeapon = 0;
                Player.instance.slots[0].GetComponent<SpriteRenderer>().color = activeSlot;
                Player.instance.slots[1].GetComponent<SpriteRenderer>().color = inactiveSlot;
                Player.instance.slots[2].GetComponent<SpriteRenderer>().color = inactiveSlot;
                Player.instance.slots[3].GetComponent<SpriteRenderer>().color = inactiveSlot;
            }
        }
        //Switches weapon to slot 2 if the player has that weapon
        if (Input.GetKey("2"))
        {
            if (Player.instance.currentWeapons[1] == true)
            {
                Player.instance.activeWeapon = 1;
                Player.instance.slots[0].GetComponent<SpriteRenderer>().color = inactiveSlot;
                Player.instance.slots[1].GetComponent<SpriteRenderer>().color = activeSlot;
                Player.instance.slots[2].GetComponent<SpriteRenderer>().color = inactiveSlot;
                Player.instance.slots[3].GetComponent<SpriteRenderer>().color = inactiveSlot;
            }
        }
        //Switches weapon to slot 3 if the player has that weapon
        if (Input.GetKey("3"))
        {
            if (Player.instance.currentWeapons[2] == true)
            {
                Player.instance.activeWeapon = 2;
                Player.instance.slots[0].GetComponent<SpriteRenderer>().color = inactiveSlot;
                Player.instance.slots[1].GetComponent<SpriteRenderer>().color = inactiveSlot;
                Player.instance.slots[2].GetComponent<SpriteRenderer>().color = activeSlot;
                Player.instance.slots[3].GetComponent<SpriteRenderer>().color = inactiveSlot;
            }
        }
        //Switches weapon to slot 4 if the player has that weapon
        if (Input.GetKey("4"))
        {
            if (Player.instance.currentWeapons[3] == true)
            {
                Player.instance.activeWeapon = 3;
                Player.instance.slots[0].GetComponent<SpriteRenderer>().color = inactiveSlot;
                Player.instance.slots[1].GetComponent<SpriteRenderer>().color = inactiveSlot;
                Player.instance.slots[2].GetComponent<SpriteRenderer>().color = inactiveSlot;
                Player.instance.slots[3].GetComponent<SpriteRenderer>().color = activeSlot;
            }
        }
    }
}
