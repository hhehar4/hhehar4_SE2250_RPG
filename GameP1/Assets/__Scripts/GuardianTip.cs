using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianTip : MonoBehaviour
{
    private bool read = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !read)
        {
            Player.instance.textField.text = "That looks like a guardian, magic does not work against them.";
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
