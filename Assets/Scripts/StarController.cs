using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour {

    public int starCount;
    public Text starText;

    protected GameObject levelRequirement;
    protected GameObject director;

    public AudioClip starNoise;
    private AudioSource source;

    private void Start()
    {

        director = GameObject.Find("EventSystem");

        starText.text = ("Stars:" + starCount + "/" + director.gameObject.GetComponent<Director>().gameLevelStars);
        source = GetComponent<AudioSource>();

    }

    private void Update()
    {
        levelRequirement = GameObject.Find("LevelStarRequirement");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Star")
        {
            AddStar();
            source.PlayOneShot(starNoise, 1);
            Destroy(collision.gameObject);
            levelRequirement.gameObject.GetComponent<levelStarRequirement>().starsInLevel = levelRequirement.gameObject.GetComponent<levelStarRequirement>().starsInLevel - 1;
        }

    }

    public void AddStar()
    {

        starCount = starCount + 1;
        starText.text = ("Stars:" + starCount + "/" + director.gameObject.GetComponent<Director>().gameLevelStars);

    }

    public void LoseStars(int stars)
    {

        starCount = starCount - stars;

    }

}
