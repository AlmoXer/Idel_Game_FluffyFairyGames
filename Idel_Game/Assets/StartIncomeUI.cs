using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartIncomeUI : MonoBehaviour {

    public Text income;
    public TimeMaster timeMaster;
    public MoneyCalculator moneyCalculator;

    private void Update()
    {
        Money m = moneyCalculator.GetMoneyOffline(PlayerProfile.incomeOffline, timeMaster.GetDeltaTime());

        for (int i = PlayerProfile.player.incomeOffline.Length-1; i > 0; i--)
        {
            if(PlayerProfile.player.incomeOffline[i]>0)
            {
                string text;
                if (i > 0)
                    text = PlayerProfile.player.incomeOffline[i].ToString() + "." + (PlayerProfile.player.incomeOffline[i - 1] / 10).ToString() + " " + (char)(i+97);
                else
                    text = PlayerProfile.player.incomeOffline[i].ToString() + " " + (char)(i + 97);


                income.text = text;
                return;
            }
        }
       
    }
}
