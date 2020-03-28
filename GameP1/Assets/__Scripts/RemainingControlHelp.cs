using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingControlHelp : MonoBehaviour
{
    //Controls the health/shooting tutorial message
    private bool read = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !read)
        {
            Player.instance.textField.text = "Walk over the red orbs to regain some health. Rightclick with your mouse to use your ice magic.";
            read = true;
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
