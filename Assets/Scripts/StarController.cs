using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour {

    public Text starText;

    public int starCount;

    private void Start()
    {

        starText.text = "Stars: " + starCount;

    }

    public void AddStars()
    {

        starCount = starCount + 10;
        starText.text = "Stars: " + starCount;

    }

    public void LoseStars(int stars)
    {

        starCount = starCount - stars;
        starText.text = "Stars: " + starCount;

    }

}
