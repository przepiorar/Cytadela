using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInstance : MonoBehaviour, IClickable
{
    public CardVizu viz;
    public GE_Logic currentLogic;
    public PlayerController player;

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
    }
}
