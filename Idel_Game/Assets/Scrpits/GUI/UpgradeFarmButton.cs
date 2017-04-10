using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFarmButton : MonoBehaviour {

    private Farm farm = new Farm();
    private Money moneyPlayer = new Money();

    public void UpgradeFarm()
    {
        //Das (int[])Geld vom Spieler wird in eine Moneyklasse übertragen 
        moneyPlayer = PlayerProfile.playerProfile.GetMoney();
        farm.moneyCalculator.SubMoney(moneyPlayer, farm.GetUpgradeCosts());
        farm.level++;

        PlayerProfile.player.farmLevels[farm.POS] = farm.level;

        //Money an den Spieler übertragen
        for (int i = 0; i < PlayerProfile.player.money.Length; i++)
            PlayerProfile.player.money[i] = moneyPlayer.money[i];
        
    }

    public void SetFarm(Farm _farm) { farm = _farm; }
}
