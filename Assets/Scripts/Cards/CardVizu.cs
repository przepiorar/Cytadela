using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVizu : MonoBehaviour {
    
    public Card card;

    public Image image;

    private void Start()
    {
        LoadCard(card);
    }
    public void LoadCard(Card c)
    {
        if (c == null)
        {
            return;
        }
        image.sprite = card.art;
    }
    void OnMouseDown()
    {
        Debug.Log("dupa");
    }
}
