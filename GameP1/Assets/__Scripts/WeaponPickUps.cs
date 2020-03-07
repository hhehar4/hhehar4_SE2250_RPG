using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUps : MonoBehaviour
{
    public GameObject[] weapons;
    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Transform pos = this.gameObject.GetComponent<Transform>();
            Destroy(this.gameObject);
            Player.instance.currentWeapons[id] = true;
        }
    }
}
