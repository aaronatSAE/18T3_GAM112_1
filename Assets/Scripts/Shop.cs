using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public GameObject shopDetector;
    public GameObject shopMenu;

    public GameObject player;

    public int capeCost;
    public int bootCost;
    public int goggleCost;

    public Text capeText;
    public Text bootText;
    public Text goggleText;

    public AudioClip shopNoise;
    private AudioSource source;

    private void Start()
    {

        shopMenu.SetActive(false);
        player = GameObject.FindWithTag("Player");
        source = GetComponent<AudioSource>();
        //shopMenu = GameObject.FindWithTag("ShopMenu");

    }

    private void Update()
    {

        capeText.text = "Jump Cape! Only " + capeCost + " stars!";
        bootText.text = "Speed Boots! Only " + bootCost + " stars!";
        goggleText.text = "Blink Goggles! Only " + goggleCost + " stars!";

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

    public void BuyBoots()
    {

        if (player.gameObject.GetComponent<StarController>().starCount >= bootCost)
        {
            player.gameObject.GetComponent<StarController>().LoseStars(bootCost);
            player.gameObject.GetComponent<PlayerController>().hasBoots = true;
            source.PlayOneShot(shopNoise, 1);
        }

    }

    public void BuyGoggles()
    {

        if (player.gameObject.GetComponent<StarController>().starCount >= goggleCost)
        {
            player.gameObject.GetComponent<StarController>().LoseStars(goggleCost);
            player.gameObject.GetComponent<PlayerController>().hasGoggles = true;
            source.PlayOneShot(shopNoise, 1);
        }

    }

}
