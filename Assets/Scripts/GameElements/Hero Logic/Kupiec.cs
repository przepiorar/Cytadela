using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/kupiec")]
public class Kupiec : Hero_Logic
{
    public override void OnStart()
    {
        int count = 0;
        foreach (CardInstance item in Settings.gameManager.currentPlayer.cardsDown)
        {
            if (item.viz.card.colour == "green")
            {
                count++;
            }            
        }
        Settings.gameManager.currentPlayer.currentGold += count+1;
        Settings.gameManager.currentPlayer.UpdateGold();
    }

    public override void Active()
    {
    }

}
