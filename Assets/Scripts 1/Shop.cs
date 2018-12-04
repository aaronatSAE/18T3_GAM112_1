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
    public AudioClip notEnoughMoney;
    private AudioSource source;

    private void Start()
    {

        shopMenu.SetActive(false);
        player = GameObject.FindWithTag("Director");
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

      //  if(player.gameObject.GetComponent<Director>().inRange == true)
       // {
            shopMenu.SetActive(true);
      //  }

    }

    public void CloseShop()
    {

        shopMenu.SetActive(false);

    }

    public void BuyCape()
    {

        if(player.gameObject.GetComponent<Director>().gameCurrency >= capeCost && player.gameObject.GetComponent<BasicPlayerLocomotions>().isCape == false)
        {
            player.gameObject.GetComponent<Director>().LoseCurrency(capeCost);
            player.gameObject.GetComponent<BasicPlayerLocomotions>().isCape = true;
            source.PlayOneShot(shopNoise, 1);
        }
        else
        {
            source.PlayOneShot(notEnoughMoney, 1);
        }

    }

    public void BuyBoots()
    {

        if (player.gameObject.GetComponent<Director>().gameCurrency >= bootCost && player.gameObject.GetComponent<BasicPlayerLocomotions>().isBoots == false)
        {
            player.gameObject.GetComponent<Director>().LoseCurrency(bootCost);
            player.gameObject.GetComponent<BasicPlayerLocomotions>().isBoots = true;
            source.PlayOneShot(shopNoise, 1);
        }
        else
        {
            source.PlayOneShot(notEnoughMoney, 1);
        }

    }

    public void BuyGoggles()
    {

        if (player.gameObject.GetComponent<Director>().gameCurrency >= goggleCost && player.gameObject.GetComponent<BasicPlayerLocomotions>().isGoggles == false)
        {
            player.gameObject.GetComponent<Director>().LoseCurrency(goggleCost);
            player.gameObject.GetComponent<BasicPlayerLocomotions>().isGoggles = true;
            source.PlayOneShot(shopNoise, 1);
        }
        else
        {
            source.PlayOneShot(notEnoughMoney, 1);
        }

    }

}
