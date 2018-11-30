using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Heroes/zlodziej")]
public class Zlodziej : Hero_Logic
{
    public override void OnStart()
    {
    }

    public override void Active()
    {
        for (int i = 1 ; i < Settings.gameManager.heroesButton.Count; i++)
        {
            Settings.gameManager.heroesButton[i].gameObject.SetActive(true);
        }
    }

}
