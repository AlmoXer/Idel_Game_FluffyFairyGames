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

    private MoneyCalculator moneyCalculator;

    void Awake()
    {
        moneyCalculator = FindObjectOfType<MoneyCalculator>();
    }


    public void UpdateData(Farm _farm)
    {
        if(_farm.ID != -1)
        {
            iconFarm.sprite = FarmArchiv.instance.allFarmes[_farm.ID].Icon;
            levelFram.text = _farm.level.ToString();

            //Income Offline Anzeigen  
            incomeOffline.text = moneyCalculator.GetMoneyString(_farm.incomeOffline);

            //Income Online Anzeigen
            incomeOnline.text = moneyCalculator.GetMoneyString(_farm.incomeOnline);

            countFelder.text = _farm.countFields.ToString();
        }

    }
}
