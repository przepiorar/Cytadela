using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Heroes/krol")]
public class Krol : Hero_Logic
{
    public override void OnStart()
    {
        int count = 0;
        foreach (CardInstance item in Library.gameManager.currentPlayer.cardsDown)
        {
            if (item.viz.card.colour == "yellow" || item.viz.card.sprite.name == "szkolaMagii")
            {
                count++;
            }
        }
        Library.gameManager.currentPlayer.currentGold += count;
        Library.gameManager.currentPlayer.UpdateGold();
        // niepotrzebne
        //for (int i = 0; i < Settings.gameManager.allPlayers.Count; i++)
        //{
        //    if (Settings.gameManager.currentPlayer == Settings.gameManager.allPlayers[i])
        //    {
        //        Settings.gameManager.kingIndeks = i;
        //        //korona.SetActive
        //    }
        //}
    }


    public override void Active()
    {
    }
}