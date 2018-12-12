using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/architekt")]
public class Architekt : Hero_Logic
{
    public override void OnStart()
    {
        Library.gameManager.currentPlayer.PickCard();
        Library.gameManager.currentPlayer.PickCard();
        Library.gameManager.currentPlayer.built = 3;
    }

    public override void Active()
    {
    }

}