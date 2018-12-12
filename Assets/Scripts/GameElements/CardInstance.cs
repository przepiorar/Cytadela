using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstance : MonoBehaviour, IClickable
{
    public CardVizual viz;
    public CardLogic currentLogic;
    public PlayerController player;

    void Start()
    {
        viz = GetComponent<CardVizual>();
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
        currentLogic.OnHighlight(this);
    }
}
