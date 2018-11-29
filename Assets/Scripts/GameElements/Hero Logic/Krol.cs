using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/krol")]
public class Krol : Hero_Logic
{
    public override void OnStart()
    {
        int count = 0;
        foreach (CardInstance item in Settings.gameManager.currentPlayer.cardsDown)
        {
            if (item.viz.card.colour == "yellow")
            {
                count++;
            }
        }
        Settings.gameManager.currentPlayer.currentGold += count;
        Settings.gameManager.currentPlayer.UpdateGold();
        foreach (PlayerController pc in Settings.gameManager.allPlayers)
        {
            pc.king = false;
        }
        Settings.gameManager.currentPlayer.king = true;
    }


    public override void Active()
    {
    }

}