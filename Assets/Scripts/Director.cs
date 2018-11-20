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

    public GameObject doorClosed;
    public GameObject doorOpen;
    public GameObject player;

    protected GameObject levelStarRequirement;


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

       


    }
	
	// Update is called once per frame
	void Update () {

        doorClosed = GameObject.FindWithTag("ClosedDoor");
        levelStarRequirement = GameObject.Find("LevelStarRequirement");

        if (player.gameObject.GetComponent<StarController>().starCount >= gameLevelStars)
        {
            
            DoorOpen(); 
            //CompleteLevel();

        }


    }

    public void DoorOpen()
    {

        doorClosed.gameObject.GetComponent<FinishDoor>().hasEnoughStars = true;
        Debug.Log("Got Enough Stars");

        doorClosed.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        //gameLevel += 1;
        //gameStars = 0;
        ////door.gameObject.GetComponent<Open>().isOpen = true;

        //if (gameLevel == 3)
        //{
        //    gameLevel = 1;
        //    gameWorld += 1;
        //}


        //door.gameObject.GetComponent<Open>().isOpen = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameLevelText.text = ("World\n" + gameWorld + "-" + gameLevel);
        gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
        playerLivesText.text = ("Lives:" + playerLives);
    }


   //public void CompleteLevel()
   // {

   //     gameLevel += 1;
   //     gameStars = 0;
   //     if (gameLevel == 3)
   //     {
   //         gameLevel = 1;
   //         gameWorld += 1;
   //     }

   //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   //     gameLevelText.text = ("World\n" + gameWorld + "-" + gameLevel);
   //     gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
   //     playerLivesText.text = ("Lives:" + playerLives);

   // }

    public void ReloadLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameLevelText.text = ("World\n" + gameWorld + "-" + gameLevel);
        gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
        playerLivesText.text = ("Lives:" + playerLives);

    }

    public void LoseLevel()
    {

        playerLives -= 1;
        gameStars = 0;
        if (playerLives <= 0)
        {
            gameOver();
        }
        else
        {
            ReloadLevel();
        }
       



    }

    //public void getStar()
    //{

    //    gameStars += 1;
    //    gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
    //}

    //public void updateStars()
    //{
    //    gameStarsText.text = ("Stars:" + gameStars + "/" + gameLevelStars);
    //}

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
        playerLivesText.text = ("Lives:" + playerLives);




    }


}
