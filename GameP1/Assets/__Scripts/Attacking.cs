using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] weapons;
    GameObject attack = null;
    private float[] coolDownTimes = { 0.4f, 1.25f, 0.75f, 1f };
    private float nextFireTime = 0;

    // Update is called once per frame
    void Update()
    {
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
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, -0.2f));
        clickPosition.z = -0.2f;

        bool positionCheck = clickPosition.x < spawnPoint.transform.position.x;

        clickPosition.x = clickPosition.x - spawnPoint.transform.position.x;
        clickPosition.y = clickPosition.y - spawnPoint.transform.position.y;

        float angle = Vector3.Angle(transform.up, clickPosition);

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

        Invoke("DestroyWeapon", 0.05f);
    }

    void DestroyWeapon()
    {
        Destroy(attack);
    }
}
