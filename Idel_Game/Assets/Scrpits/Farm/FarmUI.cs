using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmUI : MonoBehaviour {

    public Farm farm;
    public Image icon;
    public Text level;
    public Text stack;

    public MoneyCalculator moneyCalculator;
    //public Image canUpgradeIcon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (farm.ID == -1)
            return;

        level.text = farm.level.ToString();
        icon.sprite = FarmArchiv.instance.allFarmes[farm.ID].Icon;

        Money m = farm.stack;

        for (int i = m.money.Length - 1; i >= 0; i--)
        {
            if (m.money[i] > 0)
            {
                string text;
                if (i > 0)
                    text = m.money[i].ToString() + "." + (PlayerProfile.player.incomeOffline[i - 1] / 10).ToString() + " " + (char)(i + 97);
                else
                    text = m.money[i].ToString() + " " + (char)(i + 97);


                stack.text = text;
                return;
            }
        }
    }
}
