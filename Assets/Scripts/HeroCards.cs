using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCards : MonoBehaviour {
    
    public CardVizu cardViz;
    
    void Start ()
    {
        CloseCard();
    }

    public void CloseCard()
    {
        cardViz.gameObject.SetActive(false);
    }
}
