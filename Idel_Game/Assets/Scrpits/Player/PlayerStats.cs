using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public Text incomeOffline;
    public Text incomeOnline;
    public Text money;
    public Text rank;

    private Money moneyPlayer = new Money();

    MoneyCalculator moneyCalculator;
	// Use this for initialization
	void Start () {
        moneyCalculator = this.GetComponent<MoneyCalculator>();
	}

    // Update is called once per frame
    void Update () {

        //Income Offline Anzeigen
        for (int i = 0; i < PlayerProfile.player.incomeOffline.Length; i++)        
            moneyPlayer.money[i] = PlayerProfile.player.incomeOffline[i];
        incomeOffline.text = moneyCalculator.GetMoneyString(moneyPlayer) + "/s";

        //Income Offline Anzeigen
        for (int i = 0; i < PlayerProfile.player.incomeOnline.Length; i++)
            moneyPlayer.money[i] = PlayerProfile.player.incomeOnline[i];
        incomeOnline.text = moneyCalculator.GetMoneyString(moneyPlayer) + "/s";

        //Geld Anzeigen
        for (int i = 0; i < PlayerProfile.player.money.Length; i++)
            moneyPlayer.money[i] = PlayerProfile.player.money[i];
        money.text = moneyCalculator.GetMoneyString(moneyPlayer);
        
        //Titel Anzeigen
        rank.text = PlayerProfile.player.rank;
    }

   
}
