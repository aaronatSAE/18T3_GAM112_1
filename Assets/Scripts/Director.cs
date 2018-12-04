using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour {


    public float gameLevel;
    public float gameWorld;
    public float playerLives;
    public float gameCurrency;
    public float gameStars;
    public float gameLevelStars;

    public Text gameLevelText;
    public Text gameWorldText;
    public Text playerLivesText;
    public Text gameCurrencyText;
    public Text gameStarsText;
	
	public GameObject Door;


	// Use this for initialization
	void Start () {

        gameLevel = 0;
        gameWorld = 1;
        playerLives = 3;
        gameCurrency = 0;
        gameStars = 0;
        gameLevelStars = 0;

        gameLevelText.text = ("World\n" + gameWorld + "-" + gameLevel);
        gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
        playerLivesText.text = ("Lives:" + playerLives);
		
		Door = GameObject.FindWithTag("Door");
		Door.GetComponent<FinishDoor>().hasEnoughStars = false;

		CompleteLevel();
    }
	
	// Update is called once per frame
	void Update () {

        if (gameStars >= gameLevelStars)
        {
            OpenDoor();
        } else
		{
			Door.GetComponent<FinishDoor>().hasEnoughStars = false;
		}
		
	}


   public void CompleteLevel()
    {

        gameLevel += 1;
        gameStars = 0;
		Door.GetComponent<FinishDoor>().hasEnoughStars = false;
        if (gameLevel == 9)
        {
            gameLevel = 1;
            gameWorld += 1;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameLevelText.text = ("World\n" + gameWorld + "-" + gameLevel);
        gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
			gameCurrencyText.text = ("$" + gameCurrency);
        playerLivesText.text = ("Lives:" + playerLives);

    }

    public void ReloadLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameLevelText.text = ("World\n" + gameWorld + "-" + gameLevel);
        gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
			gameCurrencyText.text = ("$" + gameCurrency);
        playerLivesText.text = ("Lives:" + playerLives);
		Door.GetComponent<FinishDoor>().hasEnoughStars = false;

    }

    public void LoseLevel()
    {

        playerLives -= 1;
        gameStars = 0;
		Door.GetComponent<FinishDoor>().hasEnoughStars = false;
        if (playerLives <= 0)
        {
            gameOver();
        }
        else
        {
            ReloadLevel();
        }
       



    }

    public void getStar()
    {

        gameStars += 1;
		gameCurrency += 1;
        gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
		gameCurrencyText.text = ("$" + gameCurrency);
    }

    public void updateStars()
    {
        gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
		gameCurrencyText.text = ("$" + gameCurrency);
    }

    public void gameOver()
    {

        gameLevel = 1;
        gameWorld = 1;
        playerLives = 3;
        gameCurrency = 0;
        gameStars = 0;
    //    SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Level1");
        gameLevelText.text = ("World\n" + gameWorld + "-" + gameLevel);
        gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
			gameCurrencyText.text = ("$" + gameCurrency);
        playerLivesText.text = ("Lives:" + playerLives);




    }
	
	public void OpenDoor()
	{
		//CompleteLevel();
		Door.GetComponent<FinishDoor>().hasEnoughStars = true;
	}
	
	    public void LoseCurrency(int Currency)
    {

        gameCurrency = gameCurrency - Currency;
        gameCurrencyText.text = ("$" + gameCurrency);

    }


}
