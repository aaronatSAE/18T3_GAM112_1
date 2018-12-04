﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Sound()
    {
        audioSource.PlayOneShot(sound, 1);
    }
}
