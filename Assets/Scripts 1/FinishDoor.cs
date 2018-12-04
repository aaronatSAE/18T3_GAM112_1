using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour {

    public bool hasEnoughStars = false;
	public GameObject director;
	private SpriteRenderer spriteR;
	public Sprite DoorOpen;
	public Sprite Door;
	private GameObject childobj;
	
	void Start(){
		director = GameObject.FindWithTag("Director");
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		childobj =  this.gameObject.transform.GetChild(0).gameObject;
		childobj.SetActive(false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && hasEnoughStars == true)
        {
            director.GetComponent<Director>().CompleteLevel();
        }

    }
	
	void Update(){
		
		if (hasEnoughStars){
			
			spriteR.sprite = DoorOpen;
			childobj.SetActive(true);
		}else {
			spriteR.sprite = Door;
			childobj.SetActive(false);
		}
		
	}

}
