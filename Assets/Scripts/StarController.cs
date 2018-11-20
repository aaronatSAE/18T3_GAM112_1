using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour {

    public int starCount;
    public Text starText;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Star")
        {
            AddStar();
            Destroy(collision.gameObject);
        }

    }

    public void AddStar()
    {

        starCount = starCount + 1;

    }

    public void LoseStars(int stars)
    {

        starCount = starCount - stars;

    }

}
