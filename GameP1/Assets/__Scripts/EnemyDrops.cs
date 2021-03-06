﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public int expAmount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Controls player exp adding and leveling

        if (collision.tag == "Player")
        {
            //Increases the player's experience by the drop's amount
            Player.instance.experience += expAmount;
            //If the player gets to over 200 base exp, they level up
            if (Player.instance.experience > 200 && !Player.instance.levelUp2)
            {
                Player.instance.textField.text = "Level up! Your magic now does more damage, is faster, and has infinite range.";
                Player.instance.level = 2;
                Player.instance.levelUp2 = true;
                Invoke("RemoveText", 3);
            }
            //If the player gets to over 100 bsae exp, they level up
            else if (Player.instance.experience > 100 && !Player.instance.levelUp1)
            {
                Player.instance.textField.text = "Level up! Your magic now does more damage, is faster, and has more range.";
                Player.instance.levelUp1 = true;
                Player.instance.level = 1;
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
