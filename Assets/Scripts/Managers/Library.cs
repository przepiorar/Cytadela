using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Library
{
    public static GameManager gameManager;
    public static List<RaycastResult> GetUIElements()  // zwraca liste obiektów w które klikniemy
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        return results;
    }

    public static void SetParentCard(Transform c, Transform p)
    {
        c.SetParent(p.transform);
        c.localPosition = Vector3.zero;
        c.localEulerAngles = Vector3.zero;
        c.localScale = Vector3.one;
    }

    public static void MirrorRotation()
    {
        int a;
        if (gameManager.currentPlayer == gameManager.allPlayers[0])
            a = -1;
        else
            a = 1;

        if (gameManager.indeks + 1 >= gameManager.order.Count)
            gameManager.indeks = 0;
        else
            gameManager.indeks++;
        gameManager.currentPlayer = gameManager.order[gameManager.indeks];

        GameObject[] test = GameObject.FindGameObjectsWithTag("test");
        foreach (GameObject item in test)
        {
            item.transform.localScale = new Vector3(item.transform.localScale.x, a * Mathf.Abs( item.transform.localScale.y), item.transform.localScale.z);
        }
        gameManager.currentPlayer.tableGrid.transform.localScale = new Vector3(0.8f, a*0.8f, 0.8f);
        gameManager.order[gameManager.allPlayers.Count-1- gameManager.indeks].tableGrid.transform.localScale = new Vector3(0.8f, a*0.8f, 0.8f);
        GameObject.FindGameObjectWithTag("Selected").transform.localScale = new Vector3(1, a*1, 1);
        GameObject.FindGameObjectWithTag("Highlighted").transform.localScale = new Vector3(1, a*1, 1);
    }

    public static List<int> RandomHero()
    {
        int j = 8;
        List<int> list = new List<int> { 0,1, 2, 3, 4, 5, 6, 7};
        List<int> tmp = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            int a =Random.Range(0, j);
            tmp.Add(list[a]);
            list.RemoveAt(a);
            j--;
        }
        return tmp;
    }

    public static void HidePickedHero()
    {
        Card tmpCard = gameManager.HeroPickGrid[gameManager.HeroPickGrid.Count - 1].card;
        int index = 0;
        for (int i = 0; i < gameManager.HeroPickGrid.Count; i++)
        {
            if (gameManager.HeroPickGrid[i].card == gameManager.currentPlayer.currentHero)
            {
                index = i;
                break;
            }
        }
        gameManager.HeroPickGrid[index].card = tmpCard;
        gameManager.HeroPickGrid[index].LoadCard(tmpCard);
        gameManager.HeroPickGrid[gameManager.HeroPickGrid.Count - 1].gameObject.SetActive(false);
    }

    public static void HeroPickFaze(bool b)
    {
        gameManager.heroTurn = b;
        foreach (CardVizu item in gameManager.HeroPickGrid) //ukrycie/pokazanie postaci do wybrania
        {
            item.gameObject.SetActive(b);
        }
        if (b)
        {
            List<int> cyfry = RandomHero();
            for (int i = 0; i < gameManager.HeroPickGrid.Count; i++)
            {
                gameManager.HeroPickGrid[i].LoadCard(gameManager.allHeroCards[cyfry[i]]);
            }
            foreach (PlayerController pc in gameManager.allPlayers) //ukrycie bohaterow na rece
            {
                pc.heroCard.gameObject.SetActive(false);
            }
        }
    }

    public static void SortByHero()
    {
        gameManager.order = new List<PlayerController>();
        gameManager.order.Add(gameManager.allPlayers[0]);
        for (int i = 1; i < gameManager.allPlayers.Count; i++)
        {
            for (int j = 0; j < gameManager.order.Count; j++)
            {
                if (gameManager.allPlayers[i].currentHero.value < gameManager.order[j].currentHero.value)
                {
                    gameManager.order.Insert(j, gameManager.allPlayers[i]);
                    break;
                }
                else
                {
                    if (j + 1 == gameManager.order.Count)
                    {
                        gameManager.order.Add(gameManager.allPlayers[i]);
                        break;
                    }
                }
            }
        }
    }
    public static void SortByKing()
    {
        for (int i = 0; i < gameManager.allPlayers.Count; i++)  //sprawdzenie czy król nie był wybrany w ostatniej turze
        {
            if (gameManager.allPlayers[i].currentHero != null && gameManager.allPlayers[i].currentHero.value == 4)
            {
                gameManager.allPlayers[gameManager.kingIndeks].PlayerCrown.gameObject.SetActive(false);
                gameManager.kingIndeks = i;
                gameManager.allPlayers[gameManager.kingIndeks].PlayerCrown.gameObject.SetActive(true);
                break;
            }
        }
        gameManager.order = new List<PlayerController>();
        int a = Library.gameManager.kingIndeks;
        gameManager.order.Add(gameManager.allPlayers[a]);
        a++;
        for (int i = 1; i < gameManager.allPlayers.Count; i++)
        {
            if (a>= gameManager.allPlayers.Count)
            {
                a = 0;
            }
            gameManager.order.Add(gameManager.allPlayers[a]);
        }
    }

    public static void PickButtons(bool b)
    {
        gameManager.picked = !b;
        gameManager.goldButton.gameObject.SetActive(b);
        gameManager.cardButton.gameObject.SetActive(b);
    }

    public static void EndGame()
    {
        int score = 0;
        int index = 0;
        gameManager.endText.gameObject.SetActive(true);
        if (gameManager.currentPlayer == gameManager.allPlayers[1])
        {
            gameManager.endText.transform.localScale = new Vector3(gameManager.endText.transform.localScale.x, -1 * gameManager.endText.transform.localScale.y, gameManager.endText.transform.localScale.z);
        }
        gameManager.endText.text = "Koniec gry! \n";
        foreach (PlayerController pl in gameManager.allPlayers)
        {
            pl.OnLogicAndGraphic();
            pl.OffLogic();
            score = 0;
            bool[] colors = new bool[5];
            if (pl == gameManager.firstEnd)
            {
                score += 2;
            }
            if (pl.cardsDown.Count >= gameManager.cardsToEndGame)
            {
                score += 2;
            }
            for (int i = 0; i < pl.cardsDown.Count; i++)
            {
                score += pl.cardsDown[i].viz.card.value;
                switch (pl.cardsDown[i].viz.card.colour)
                {
                    case "red":
                        colors[0] = true;
                        break;
                    case "yellow":
                        colors[1] = true;
                        break;
                    case "green":
                        colors[2] = true;
                        break;
                    case "blue":
                        colors[3] = true;
                        break;
                    case "purple":
                        colors[4] = true;
                        break;
                    default:
                        break;
                }
            }
            score += 3;
            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == false)
                {
                    score -= 3;
                    break;
                }
            }
            gameManager.endText.text += "Gracz " + (index + 1) + " uzyskał: " + score + " punktów \n";
            index++;
        }
    }
}
