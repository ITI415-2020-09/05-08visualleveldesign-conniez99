using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip Swimming;
    public AudioSource audioS;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            print("in");
            audioS.clip = Swimming;
            audioS.Play();
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
    }
}


