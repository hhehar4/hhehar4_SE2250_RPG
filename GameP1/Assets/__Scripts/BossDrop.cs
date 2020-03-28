using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrop : MonoBehaviour
{    
    //Controls the boss drop scene cut
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player walks over the boss's drop, the scene fades out
        if (collision.tag == "Player")
        {
            Player.instance.hasCrystal = true;
            Player.instance.textField.color = Color.white;
            StartCoroutine(Fade());
            
            Destroy(this.gameObject, 6);
        }
    }
    private IEnumerator Fade()
    {
        //Scene starts as clear
        Player.instance.overlay.gameObject.SetActive(true);
        Player.instance.overlay.color = Color.clear;

        float rate = 1.0f / 2.0f;
        float progress = 0.0f;

        //Fades to black
        while (progress < 1.0f)
        {
            Player.instance.overlay.color = Color.Lerp(Color.clear, Color.black, progress);
            progress += rate * Time.deltaTime;

            yield return null;
        }

        Player.instance.overlay.color = Color.black;
        Player.instance.player.transform.position = new Vector3(-19, 7, 0);
        Player.instance.levelTemp.SetActive(false);

        progress = 0.0f;

        //Fades to clear
        while (progress < 1.0f)
        {
            Player.instance.overlay.color = Color.Lerp(Color.black, Color.clear, progress);
            progress += rate * Time.deltaTime;

            yield return null;
        }

        Player.instance.overlay.color = Color.clear;
        Player.instance.overlay.gameObject.SetActive(false);
    }
}
