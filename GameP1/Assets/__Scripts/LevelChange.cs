using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            if(this.gameObject.name == "LevelManagement" && Player.instance.experience < 100)
            {
                Player.instance.textField.text = "I should get all the crystals on this level before I go into the cave.";
            }
            else if (this.gameObject.name == "LevelManagement")
            {
                Player.instance.player.transform.position = new Vector3(-24, -60.5f, -0.2f);
                Player.instance.textField.color = Color.black;
                Player.instance.levelIndicator.text = "Level 2 - The Ice Caves";
            }
            else if (this.gameObject.name == "LevelManagement2" && !Player.instance.hasCrystal)
            {
                Player.instance.textField.text = "I should get the crystal for the generator before I go back to the lab.";
            }
            else
            {
                Player.instance.player.transform.position = new Vector3(27, -13, -0.2f);
                Player.instance.textField.color = Color.white;
            }
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
