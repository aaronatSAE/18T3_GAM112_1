using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipFollow : MonoBehaviour {

    public Transform target;

    private void Update()
    {

        transform.position = target.transform.position;

    }

}
