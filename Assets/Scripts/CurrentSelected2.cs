using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSelected2 : MonoBehaviour
{

    public CardVariable currentCard;
    public CardVizu cardViz;

    Transform mTransform;

    public void LoadCard()
    {
        if (currentCard.value == null)
        {
            return;
        }
        
        cardViz.LoadCard(currentCard.value.viz.card);
        cardViz.gameObject.SetActive(true);
        mTransform.position = Input.mousePosition;  //zrobic sztuczke z sign
      // Debug.Log(mTransform.position.x); // pozycja myszki jest określana na podstawie rozdzielczości !!!!
         int w = Screen.width;
        int h = Screen.height;
        if (mTransform.position.y <640*h/1020)
        {
            mTransform.position += new Vector3(0, 150*h/1020, 0);
        }
        else
        {
            mTransform.position += new Vector3(0, -150*h/1020, 0);
        }
        if (mTransform.position.x<430*w/1920)
        {
          mTransform.position += new Vector3(200*w/1920, 0, 0);
        }
        Vector3 s;
        if (w < 1000)
           s = Vector3.one * 1.5f;
        else
             s = Vector3.one * 2;
        cardViz.gameObject.transform.localScale =s;
    }

    public void CloseCard()
    {
        cardViz.gameObject.SetActive(false);
    }
    private void Start()
    {
        mTransform = this.transform;
        CloseCard(); //bo na początku nie mamy wybranej zadnej karty
    }
}