using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI TimerText;
    public GameObject loseText;
    public GameObject winText;
    static public int count = 0;
    public float timeRemaining = 180;
    static public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        loseText.SetActive(false);
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(timeRemaining / 60);
                float seconds = Mathf.FloorToInt(timeRemaining % 60);
                if (seconds < 10)
                {
                    TimerText.text = "Time Remaining: " + minutes.ToString() + ":0" + seconds.ToString();
                }
                else
                {
                    TimerText.text = "Time Remaining: " + minutes.ToString() + ":" + seconds.ToString();
                }
            }
            else
            {
                timerIsRunning = false;
                loseText.SetActive(true);
                TimerText.text = "Time Remaining: 0:00";
            }
            if (Goal.goalMet)
            {
                timerIsRunning = false;
            }
        }
        else
        {
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene("04-CollectionGame");
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Collected: " + count.ToString() + " of 15";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timerIsRunning)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;

                SetCountText();
            }
            if (other.gameObject.CompareTag("Goal"))
            {
                if (count == 15)
                {
                    Goal.goalMet = true;
                    winText.SetActive(true);
                }

            }
        }

    }

}
