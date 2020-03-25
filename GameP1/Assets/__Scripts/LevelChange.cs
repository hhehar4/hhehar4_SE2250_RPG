using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") {
            Debug.Log("Test2");
            if (this.gameObject.name == "LevelManagement")
            {
                Player.instance.player.transform.position = new Vector3(-24, -60.5f, -0.2f);
            }
            else
            {
                Player.instance.player.transform.position = new Vector3(27, -13, -0.2f);
            }
        }
    }
}
