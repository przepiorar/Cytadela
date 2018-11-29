using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/magik")]
public class Magik : Hero_Logic
{
    public override void OnStart()
    {
        int count = 0;
        foreach (CardInstance item in Settings.gameManager.currentPlayer.cardsDown)
        {
            if (item.viz.card.colour == "red")
            {
                count++;
            }
        }
        Settings.gameManager.currentPlayer.currentGold += count;
        Settings.gameManager.currentPlayer.UpdateGold();
    }

    public override void Active()
    {
    }

}
