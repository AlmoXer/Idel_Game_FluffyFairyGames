using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsFarmUI : MonoBehaviour {

    public Text title;
    public Image iconFarm;
    public Text levelFram;
    public Text incomeOffline;
    public Text incomeOnline;
    public Text countFelder;
    public Text costUpgrade;

    public MoneyCalculator moneyCalculator;

    public void UpdateData(Farm _farm)
    {
        iconFarm.sprite = FarmArchiv.instance.allFarmes[_farm.ID].Icon;
        levelFram.text = _farm.level.ToString();

        //Income Offline Anzeigen
        for (int i = _farm.incomeOffline.money.Length - 1; i >= 0; i--)        
            if (_farm.incomeOffline.money[i] > 0)
            {
                string text;
                if (i > 0)
                    text = _farm.incomeOffline.money[i].ToString() + "." + (_farm.incomeOffline.money[i - 1] / 10).ToString() + " " + (char)(i + 97);
                else
                    text = _farm.incomeOffline.money[i].ToString() + " " + (char)(i + 97);

                incomeOffline.text = text;
                break;
            }

        //Income Online Anzeigen
        for (int i = _farm.incomeOnline.money.Length - 1; i >= 0; i--)
            if (_farm.incomeOnline.money[i] > 0)
            {
                string text;
                if (i > 0)
                    text = _farm.incomeOnline.money[i].ToString() + "." + (_farm.incomeOnline.money[i - 1] / 10).ToString() + " " + (char)(i + 97);
                else
                    text = _farm.incomeOnline.money[i].ToString() + " " + (char)(i + 97);

                incomeOnline.text = text;
                break;
            }

        countFelder.text = _farm.countFields.ToString();

    }
}
