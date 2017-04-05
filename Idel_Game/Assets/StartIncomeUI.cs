using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartIncomeUI : MonoBehaviour {

    public Text income;
    public TimeMaster timeMaster;
    private void Update()
    {
        income.text = (timeMaster.GetDeltaTime() * PlayerProfile.player.incomeOffline).ToString();
    }
}
