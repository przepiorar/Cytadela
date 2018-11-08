using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMover : MonoBehaviour {

    Transform mtransform;
	
	void Start ()
    {
        mtransform = this.transform;
	}
	
	
	void Update ()
    {
        mtransform.position = Input.mousePosition;
	}
}
