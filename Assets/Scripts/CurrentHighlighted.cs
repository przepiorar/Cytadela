using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentHighlighted : MonoBehaviour
{
    //public CardVariable currentCard;
    public CardVizu cardViz;
    Transform mTransform;

    public void LoadCard()
    {
        if (Library.gameManager.cardVariable == null)
        {
            return;
        }
        
        cardViz.LoadCard(Library.gameManager.cardVariable.viz.card);
        cardViz.gameObject.SetActive(true);
        mTransform.position = Input.mousePosition; 
      // Debug.Log(mTransform.position.x); // pozycja myszki jest określana na podstawie rozdzielczości !!!!
        float w = Screen.width;
        float h = Screen.height;
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
        Vector3 s = Vector3.one * 1.5f;
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