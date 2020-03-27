using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUps : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player walks over the weapon pickups, the weapon is removed from the map and enabled in the player's inventory
        if(collision.tag == "Player")
        {
            Player.instance.currentWeapons[id] = true;
            if(id == 3)
            {
                Player.instance.inv[id].SetActive(true);
                Player.instance.textField.text = "A staff does low melee damage but boosts the damage of your magic by 1.5x.";
                Invoke("RemoveText", 3);
            }
            if (id == 2)
            {
                Player.instance.inv[id].SetActive(true);
                Player.instance.textField.text = "A spear has more range and more damage than a sword but attacks slower.";
                Invoke("RemoveText", 3);
            }
            if (id == 1)
            {
                Player.instance.inv[id].SetActive(true);
                Player.instance.textField.text += "Use the 1-4 keys to change your active weapon once you pickup a new one. ";
                Invoke("RemoveText", 3);
            }
            this.gameObject.SetActive(false);
        }
    }

    void RemoveText()
    {
        Player.instance.textField.text = "";
        Destroy(this.gameObject, 4);
    }
}
