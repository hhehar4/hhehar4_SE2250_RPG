using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    //Controls the melee attacks, specifically: weapon spawn/destruction, direction of spawn

    public GameObject spawnPoint;
    public GameObject[] weapons;
    GameObject attack = null;
    private float[] coolDownTimes = { 0.4f, 0.75f, 1.50f, 1f };
    private float nextFireTime = 0;

    void Update()
    {
        //Checks if mouse is clicked and if the cooldown is over
        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time > nextFireTime)
            {
                Attack(Player.instance.activeWeapon);
                nextFireTime = Time.time + coolDownTimes[Player.instance.activeWeapon];
            }
        }
    }

    void Attack(int tracker)
    {
        //Gets the mouse position on click
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, -0.2f));
        clickPosition.z = -0.2f;

        bool positionCheck = clickPosition.x < spawnPoint.transform.position.x;

        clickPosition.x = clickPosition.x - spawnPoint.transform.position.x;
        clickPosition.y = clickPosition.y - spawnPoint.transform.position.y;

        float angle = Vector3.Angle(transform.up, clickPosition);

        //Creates a instance of the weapon depending on where the mouse was clicked relative to the player
        if (positionCheck)
        {
            attack = Instantiate(weapons[tracker]);
            attack.transform.parent = Player.instance.player.transform;
            attack.transform.localPosition = clickPosition.normalized * 0.7f;
            attack.transform.localRotation = Quaternion.Euler(0, 0, (angle - 90f));
        }
        if (!positionCheck)
        {
            attack = Instantiate(weapons[tracker]);
            attack.transform.parent = Player.instance.player.transform;
            attack.transform.localPosition = clickPosition.normalized * 0.7f;
            attack.transform.localRotation = Quaternion.Euler(0, 180, (angle - 90f));
        }
        //Destroys the instance
        Invoke("DestroyWeapon", 0.05f);
    }

    void DestroyWeapon()
    {
        Destroy(attack);
    }
}
