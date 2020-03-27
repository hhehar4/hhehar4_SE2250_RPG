using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Player.instance.gameEnd)
        {
            Player.instance.overlay.gameObject.SetActive(true);
            StartCoroutine(FadeToBlack());
        }
    }
    private IEnumerator FadeToBlack()
    {
        string time = Time.time.ToString();
        Player.instance.overlay.gameObject.SetActive(true);
        Player.instance.overlay.color = Color.clear;

        float rate = 1.0f / 2.0f;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Player.instance.overlay.color = Color.Lerp(Color.clear, Color.black, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }

        Player.instance.overlay.color = Color.black;
        Player.instance.temp.SetActive(true);
        Player.instance.startText.gameObject.SetActive(true);
        Player.instance.startText.text = "Congrats! You have restarted the generator. Now its time to go back to sleep. Time taken: " + time + " seconds.";
    }
}
