using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVizu : MonoBehaviour {

    public Image art;
    public Card card;

    //private void Start()
    //{
    //    LoadCard(card);
    //}
    public void LoadCard(Card c)
    {
        if (c==null)
        {
            return;
        }
        card = c;
        art.sprite = c.sprite;
        
    }
}
