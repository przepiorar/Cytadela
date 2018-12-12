using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSelected : MonoBehaviour
{
    public CardVizual cardViz;
    Transform cardTransform;

    public void LoadCard()
    {
        if (Library.gameManager.cardVariable == null)
        {
            return;
        }

        Library.gameManager.cardVariable.gameObject.SetActive(false); //ukrycie karty na ręce
        cardViz.LoadCard(Library.gameManager.cardVariable.viz.card);
        cardViz.gameObject.SetActive(true);
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
    public void Update()
    {
        cardTransform.position = Input.mousePosition;
    }
}