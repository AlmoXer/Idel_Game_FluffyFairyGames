using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmIteamUI : MonoBehaviour {

    public Image icon;
    public Text cost;
    public Button button;
    public MoneyCalculator moneyCalculator;

    public void Aktuallisieren(Sprite _icon)
    {
        icon.sprite = _icon;
        if(FarmArchiv.instance.GetPositionOfIcon(_icon)!=-1)
        {
            Money m = FarmArchiv.instance.allFarmes[FarmArchiv.instance.GetPositionOfIcon(_icon)].cost;
            string text = moneyCalculator.GetMoneyString(m) ;
            cost.text = text;

            if (moneyCalculator.EnoughMoney(PlayerProfile.playerProfile.GetMoney(), m))
                button.interactable = true;
            else
                button.interactable = false;
        }

    }
}
