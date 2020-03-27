using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabText : MonoBehaviour
{
    public GameObject powerCrystal;
    private bool read = false;
    private bool read2 = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !Player.instance.hasCrystal && !read)
        {
            Player.instance.textField.text += "The generator has shutdown. I need to go into the caves and get a large crystal to restart it. ";
            Player.instance.checkedGenerator = true;
            read = true;
        }
        if (collision.tag == "Player" && Player.instance.hasCrystal && !read2)
        {
            Player.instance.textField.text = "The generator is running again, time to go back to my pod.";
            powerCrystal.transform.localScale = new Vector3(0.75f, 0.75f, 1);
            Instantiate(powerCrystal, new Vector3(-15.5f, 17.25f, 0), Quaternion.identity);
            Player.instance.gameEnd = true;
            read2 = true;
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
