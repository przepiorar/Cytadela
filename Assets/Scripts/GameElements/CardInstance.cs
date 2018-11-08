using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstance : MonoBehaviour, IClickable
{
   // public CardVizu viz;
   //// public GE_Logic currentLogic;

   // void Start()
   // {
   //     viz = GetComponent<CardVizu>();
   // }

    public void OnClick()
    {
        //if (currentLogic == null)
        //{
        //    return;
        //}
        //currentLogic.OnClick(this);
    }
    public void OnHighlight()
    {
        //if (currentLogic == null)
        // {
        //     return;
        // }
        // currentLogic.OnClick(this);

        //Debug.Log("dziala");
        Vector3 s = Vector3.one *1.5f;
        this.transform.localScale = s;
    }

}
