using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorstartingPoint : MonoBehaviour {

    public GameObject Door;

	// Use this for initialization
	void Start () {

        Door = GameObject.FindWithTag("Door");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        Door.transform.position = this.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
