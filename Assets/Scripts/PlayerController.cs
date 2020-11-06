using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI TimerText;
    private int count;
    public float timeRemaining = 180;
    private bool timerIsRunning = false;
    public GameObject winTextObject;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
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
        }
    }

    void SetCountText()
    {
        countText.text = "Collected: " + count.ToString() + " of 15";
        if (count >= 20)
        {
            winTextObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

}
