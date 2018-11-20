using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject door;
    public GameObject button;
    public float maxTimer;
    private float timer;

    

    private void Update()
    {
             
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            door.gameObject.GetComponent<Open>().isOpen = false;
            button.gameObject.GetComponent<Pressed>().isPressed = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.GetComponent<Enemy2Controller>().isDead == true)
        {

            button.gameObject.GetComponent<Pressed>().isPressed = true;
            door.gameObject.GetComponent<Open>().isOpen = true;
            timer = maxTimer;
            Debug.Log("Pressed Button!");
        }

    }

}
