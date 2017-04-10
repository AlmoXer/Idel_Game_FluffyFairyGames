using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCityButton : MonoBehaviour
{

    private City city = new City();
    private Money moneyPlayer = new Money();

    private void Start()
    {
        city = GameObject.FindObjectOfType<City>();
    }

    public void UpgradeFarm()
    {
        //Das (int[])Geld vom Spieler wird in eine Moneyklasse übertragen 
        moneyPlayer = PlayerProfile.playerProfile.GetMoney();
        city.moneyCalculator.SubMoney(moneyPlayer, city.GetUpgradeCosts());
        city.level++;

        PlayerProfile.player.cityLevel = city.level;

        //Money an den Spieler übertragen
        for (int i = 0; i < PlayerProfile.player.money.Length; i++)
            PlayerProfile.player.money[i] = moneyPlayer.money[i];

    }

}
