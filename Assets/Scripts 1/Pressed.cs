using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressed : MonoBehaviour
{
    public GameObject button;
    public GameObject buttonP;

    public bool isPressed;

    // Update is called once per frame
    void Update()
    {
        button.SetActive(!isPressed);
        buttonP.SetActive(isPressed);
    }
}
