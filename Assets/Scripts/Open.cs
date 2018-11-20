using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {

    public GameObject openDoorSprite;
    public GameObject closeDoorSprite;

    public bool isOpen;

    private void Update()
    {

        openDoorSprite.SetActive(isOpen);
        closeDoorSprite.SetActive(!isOpen);

    }

}
