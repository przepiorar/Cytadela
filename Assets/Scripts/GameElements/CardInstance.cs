using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstance : MonoBehaviour, IClickable
{
    public CardVizu viz;
    public GE_Logic currentLogic;
   // public CardVariable currentCard;

    void Start()
    {
        viz = GetComponent<CardVizu>();
    }

    public void OnClick()
    {
        if (currentLogic == null)
        {
            return;
        }
        currentLogic.OnClick(this);
    }
    public void OnHighlight()
    {
        if (currentLogic == null)
        {
            return;
        }
        Debug.Log("highlights");
        currentLogic.OnHighlight(this);

       // StartCoroutine(Czekaj());
        
    }
    //IEnumerator Czekaj()
    //{
    //    //Vector3 s = Vector3.one * 2;
    //   // this.transform.localScale = s;
    //    yield return new WaitForSeconds(1);

    //    currentLogic.OnHighlight(this);
    //    //yield return new WaitForEndOfFrame();      

    //   // this.transform.localScale = s / 2;
    //}

}
