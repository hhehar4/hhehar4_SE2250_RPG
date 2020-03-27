using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHelp : MonoBehaviour
{
    private bool read = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!Player.instance.checkedGenerator && !Player.instance.hasCrystal && !read)
            {
                Player.instance.textField.text = "I should go check on the generator before going any further.";
                Player.instance.player.transform.position = new Vector3(-5f, 6f, 0);
            }
            if(Player.instance.checkedGenerator && !Player.instance.hasCrystal && !read)
            {
                Player.instance.textField.text = "Press space to dash forward a short distance, you can jump over barricades with this. Leftclick with your mouse to attack using your active weapon.";
                read = true;
            }
            if (Player.instance.hasCrystal)
            {
                Player.instance.textField.text = "I should go put the crystal in the generator and go back to sleep.";
                Player.instance.player.transform.position = new Vector3(-5f, 6f, 0);
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
