using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/kupiec")]
public class Kupiec : Hero_Logic
{
    public override void OnStart()
    {
        int count = 0;
        foreach (CardInstance item in Library.gameManager.currentPlayer.cardsDown)
        {
            if (item.viz.card.colour == "green" || item.viz.card.sprite.name == "szkolaMagii")
            {
                count++;
            }            
        }
        Library.gameManager.currentPlayer.currentGold += count+1;
        Library.gameManager.currentPlayer.UpdateGold();
    }

    public override void Active()
    {
    }

}
