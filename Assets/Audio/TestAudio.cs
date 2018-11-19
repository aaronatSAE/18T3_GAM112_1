using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour {

    public float audioLevel = 1.0f;

    public AudioClip jump;
    public AudioClip purchase;
    public AudioClip collect;
    
    AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
    // Use with IF Statements/OnTrigger/OnCollisions
	void Update ()
    {
        audioSource.PlayOneShot(jump, audioLevel);

        audioSource.PlayOneShot(purchase, audioLevel);

        audioSource.PlayOneShot(collect, audioLevel);
    }
}
