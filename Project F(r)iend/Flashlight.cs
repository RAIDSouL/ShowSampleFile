using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    // Update is called once per frame
    public AudioClip soundOn;
    public GameObject flashlight;
    public AudioClip soundOff;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(flashlight.GetComponent<Light>().enabled == false)
            {
                flashlight.GetComponent<Light>().enabled = true;
                GetComponent<AudioSource>().clip = soundOn ;
                GetComponent<AudioSource>().Play();
            }
            else    
            {
                flashlight.GetComponent<Light>().enabled = false;
                GetComponent<AudioSource>().clip = soundOff ;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
