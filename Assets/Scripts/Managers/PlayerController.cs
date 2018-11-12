using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int[] startingCards;
    public GameObject handGrid;
    public GameObject tableGrid;
    public GE_Logic startingLogic;
    [System.NonSerialized]
    public List<CardInstance> cardsHand = new List<CardInstance>();
    [System.NonSerialized]
    public List<CardInstance> cardsDown= new List<CardInstance>();

}
