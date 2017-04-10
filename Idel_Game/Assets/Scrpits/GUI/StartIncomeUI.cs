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
        income.text = moneyCalculator.GetMoneyString(moneyCalculator.GetMoneyOffline(PlayerProfile.incomeOffline, timeMaster.GetDeltaTime()));   
       
    }
}
