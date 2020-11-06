using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip Swimming;
    public AudioClip Collect;
    public AudioSource audioS;
    public AudioMixerSnapshot MainMusic;
    public AudioMixerSnapshot OtherMusic;
    public AudioMixerSnapshot WinnerMusic;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            print("in");
            audioS.clip = Swimming;
            audioS.Play();
        }
        if (other.CompareTag("PickUp"))
        {
            if (PlayerController.timerIsRunning) //play collect sound only if there is time remaining
            {
                audioS.PlayOneShot(Collect);
            }
        }
        if (other.CompareTag("Building"))
        {
            if (!Goal.goalMet)
            {
                OtherMusic.TransitionTo(1f);
            }
        }
        if (other.CompareTag("Goal"))
        {
            if (PlayerController.count == 15)
            {
                audioS.PlayOneShot(Collect);
                WinnerMusic.TransitionTo(1f);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            print("out");
            audioS.clip = Swimming;
            audioS.Stop();
        }
        if (other.CompareTag("Building"))
        {
            if (!Goal.goalMet)
            {
                MainMusic.TransitionTo(1f);
            }
        }
    }
}


