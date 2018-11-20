using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject shopDetector;
    public GameObject shopMenu;

    public GameObject player;

    public int capeCost;

    public AudioClip shopNoise;
    private AudioSource source;

    private void Start()
    {

        shopMenu.SetActive(false);
        player = GameObject.FindWithTag("Player");
        source = GetComponent<AudioSource>();
        //shopMenu = GameObject.FindWithTag("ShopMenu");

    }

    public void OpenShop()
    {

        if(player.gameObject.GetComponent<ShopManager>().inRange == true)
        {
            shopMenu.SetActive(true);
        }

    }

    public void CloseShop()
    {

        shopMenu.SetActive(false);

    }

    public void BuyCape()
    {

        if(player.gameObject.GetComponent<StarController>().starCount >= capeCost)
        {
            player.gameObject.GetComponent<StarController>().LoseStars(capeCost);
            player.gameObject.GetComponent<PlayerController>().hasCape = true;
            source.PlayOneShot(shopNoise, 1);
        }

    }

}
