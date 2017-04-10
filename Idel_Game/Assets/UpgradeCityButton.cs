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

    public void UpgradeCity()
    {
        //Das (int[])Geld vom Spieler wird in eine Moneyklasse übertragen 
        moneyPlayer = PlayerProfile.playerProfile.GetMoney();
        city.moneyCalculator.SubMoney(moneyPlayer, city.GetUpgradeCosts());
        city.level++;

        PlayerProfile.player.cityLevel = city.level;

        city.sales.money[0] = city.sales.money[0] + (city.level*100/455);
        Money mZero = new Money();
        city.moneyCalculator.AddMoney(city.sales, mZero);

        GameObject.FindObjectOfType<Helicopter>().speed = 5.0f + (95.0f * (float)city.level / (float)city.levelMax);
        //Money an den Spieler übertragen
        for (int i = 0; i < PlayerProfile.player.money.Length; i++)
            PlayerProfile.player.money[i] = moneyPlayer.money[i];

    }

}
