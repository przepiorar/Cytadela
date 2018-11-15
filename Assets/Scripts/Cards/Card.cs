using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Card") ]
public class Card : ScriptableObject
{
    public string colour;
    public int value;
    public Sprite sprite;
}
