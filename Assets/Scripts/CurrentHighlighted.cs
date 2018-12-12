using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentHighlighted : MonoBehaviour
{
    public CardVizu cardViz;
    Transform cardTransform;

    public void LoadCard()
    {
        if (Library.gameManager.cardVariable == null)
        {
            return;
        }
        
        cardViz.LoadCard(Library.gameManager.cardVariable.viz.card);
        cardViz.gameObject.SetActive(true);
        cardTransform.position = Input.mousePosition; 
        // pozycja myszki jest określana na podstawie rozdzielczości !!!!
        float w = Screen.width;
        float h = Screen.height;
        if (cardTransform.position.y <640*h/1020)
        {
            cardTransform.position += new Vector3(0, 150*h/1020, 0);
        }
        else
        {
            cardTransform.position += new Vector3(0, -150*h/1020, 0);
        }
        if (cardTransform.position.x<430*w/1920)
        {
          cardTransform.position += new Vector3(200*w/1920, 0, 0);
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
        cardTransform = this.transform;
        CloseCard(); //bo na początku nie mamy wybranej zadnej karty
    }
}