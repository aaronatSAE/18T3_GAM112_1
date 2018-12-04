using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public GameObject shopButton;
    public GameObject shopDetector;
    public bool inRange;

    private void Update()
    {

        shopButton.SetActive(inRange);
        shopDetector = GameObject.FindWithTag("ShopDetector");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject == shopDetector)
        {
            inRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject == shopDetector)
        {
            inRange = false;
        }

    }

}
