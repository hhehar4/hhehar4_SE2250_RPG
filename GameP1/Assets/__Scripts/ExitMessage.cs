﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMessage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.instance.textField.text = "The door is frozen, you cannot leave the building.";
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("RemoveText", 3);
        }
    }

    void RemoveText()
    {
        Player.instance.textField.text = "";
    }
}
