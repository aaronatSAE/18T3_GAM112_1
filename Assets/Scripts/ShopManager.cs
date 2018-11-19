using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public GameObject shopButton;
    public bool inRange;

    private void Update()
    {

        shopButton.SetActive(inRange);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        inRange = false;

    }

}
