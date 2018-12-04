using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelStarRequirement : MonoBehaviour {

    public float starcount;
    protected GameObject director;
    protected Director directorscript;

	// Use this for initialization
	void Start () {

        director = GameObject.Find("EventSystem");
        directorscript = director.GetComponent<Director>();

        directorscript.gameLevelStars = starcount;
        directorscript.updateStars();


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
