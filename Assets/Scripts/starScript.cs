using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starScript : MonoBehaviour {

    protected GameObject director;
    protected Director directorscript;

    // Use this for initialization
    void Start () {

        director = GameObject.Find("EventSystem");
        directorscript = director.GetComponent<Director>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)


    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            directorscript.getStar();
        }
    }
}
