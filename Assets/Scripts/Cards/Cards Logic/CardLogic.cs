using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardLogic : ScriptableObject
{
    public abstract void OnClick(CardInstance card);
    public abstract void OnHighlight(CardInstance card);
}
