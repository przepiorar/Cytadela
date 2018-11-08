using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour {

     CardVizu card;
    Transform mtransform;

    void Start ()
    {
       // mtransform = this.transform;
    }
	
	
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            card = GetComponent<CardVizu>();
            card.transform.position = Input.mousePosition;
        }
	}
}
