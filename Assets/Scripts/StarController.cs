using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour {

    public float starcount;
    protected GameObject director;
    protected Director directorscript;

    public Text starText;

    public int starCount;

    private void Start()
    {
        director = GameObject.Find("EventSystem");
        directorscript = director.GetComponent<Director>();

        directorscript.gameLevelStars = starcount;
        directorscript.updateStars();
        starCount = 0;
        starText.text = "Stars: " + starCount;

    }

    public void Update()
    {


        
    }

    public void AddStars()
    {

        starCount = starCount + 1;
        starText.text = "Stars: " + starCount;

    }

    public void LoseStars(int stars)
    {

        starCount = starCount - stars;
        starText.text = "Stars: " + starCount;

    }
    private void OnTriggerEnter2D(Collider2D stars)


    {

        if (stars.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            directorscript.getStar();
        }
    }

}
