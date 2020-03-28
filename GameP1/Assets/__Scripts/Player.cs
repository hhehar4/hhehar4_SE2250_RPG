using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Singleton class to keep track of player stats

    public static Player instance = null;
    public GameObject player = null;
    public int health = 100;
    public int level = 0;
    public int activeWeapon = 0;
    public int experience = 1;
    public bool[] currentWeapons = { true, false, false, false};
    public bool hasCrystal = false;
    public Text textField;
    public bool gameEnd = false;
    public bool checkedGenerator = false;
    public bool levelUp1 = false;
    public bool levelUp2 = false;
    public GUITexture overlay;
    public Text startText;
    public Text levelIndicator;
    public GameObject temp;
    public GameObject levelTemp;
    public GameObject[] inv;
    public GameObject[] slots;

    //Initiates beginning scenes, initializes the singleton, and displays the movement tutorial message
    void Awake()
    {
        overlay.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
        temp.SetActive(true);
        overlay.gameObject.SetActive(true);
        startText.gameObject.SetActive(true);

        StartCoroutine(StartMess());
        StartCoroutine(FadeToClear());

        if (instance == null)
        {
            instance = this;    
            textField.text = "I guess the generator is out of power, I should go check on it. (Use WASD to move)";
            Invoke("RemoveText", 15);
        }
    }

    //Reloads the entire game when the player dies
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void RemoveText()
    {
        textField.text = "";
    }

    //Manages how long the initial message is displayed
    private IEnumerator StartMess()
    {
        float rate = 1.0f / 9.0f;
        float progress = 0.0f;
        while (progress < 1.0f)
        {
            progress += rate * Time.deltaTime;
            yield return null;
        }
        startText.text = "";
        temp.SetActive(false);
    }

    //Manages the fade into the game
    private IEnumerator FadeToClear()
    {
        overlay.gameObject.SetActive(true);
        yield return new WaitForSeconds(8.5f);
        overlay.color = Color.black;

        float rate = 1.0f / 2.0f;
        float progress = 0.0f;

        while(progress < 1.0f)
        {
            overlay.color = Color.Lerp(Color.black, Color.clear, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }

        overlay.color = Color.clear;
        overlay.gameObject.SetActive(false);
    }
}
