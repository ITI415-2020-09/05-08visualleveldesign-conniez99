using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    void Update()
    {
        if (PlayerController.count == 15)
        {
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 0.5f;
            mat.color = c;
        }
        if (goalMet == true)
        {
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}
