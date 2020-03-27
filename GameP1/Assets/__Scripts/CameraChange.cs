using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera cam;
    public GameObject healthBar;
    public GameObject inventoryBar;
    public GameObject levelIndicator;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.orthographicSize = 10;
            healthBar.transform.localPosition = new Vector3(-12.32f, -9.22f, 0);
            inventoryBar.transform.localPosition = new Vector3(12.32f, -9.22f, 0);
            levelIndicator.transform.localPosition = new Vector3(-1.9f, -1.35f, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cam.orthographicSize = 6;
            healthBar.transform.localPosition = new Vector3(-5.26f, -5.38f, 0);
            inventoryBar.transform.localPosition = new Vector3(5.26f, -5.38f, 0);
            levelIndicator.transform.localPosition = new Vector3(5.26f, -5.38f, 0);
        }
    }

}
