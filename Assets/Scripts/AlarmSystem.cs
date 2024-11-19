using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    public AudioSource AudioSource;
    private float volume;
    private bool OnStay = false;

    private void Update()
    {
        if (OnStay == true)
        {
            IncreaseVolume();
        }

        if (OnStay == false)
        {
            TurnDownVolume();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        OnStay = true;
    }

    private void OnTriggerExit(Collider other)
    {
        OnStay = false;
    }


    private void IncreaseVolume()
    {
        volume = Mathf.MoveTowards(volume, 0.5f, Time.deltaTime / 4);
        AudioSource.volume = volume;

        if (!AudioSource.isPlaying)
        {
            AudioSource.Play();
        }
    }

    private void TurnDownVolume()
    {
        volume = Mathf.MoveTowards(volume, 0f, Time.deltaTime / 4);
        AudioSource.volume = volume;

        if (volume == 0)
        {
            AudioSource.Stop();
        }
    }
}
