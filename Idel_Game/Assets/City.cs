using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    public int level = 1;
    public Money sales = new Money();
    public Money stack = new Money();
    private Money moneyPlayer = new Money();
    private Money money = new Money();

    public MoneyCalculator moneyCalculator;

	// Use this for initialization
	void Start () {
        moneyCalculator = this.GetComponent<MoneyCalculator>();
        InvokeRepeating("Sale", 0f, 5.0f);
    }
    
    void Sale()
    {
        //Wenn der Geld Stack in der Stadt leer ist --> Return 
        if (moneyCalculator.IsEmpty(stack))
            return;

        //Das (int[])Geld vom Spieler wird in eine Moneyklasse übertragen 
        for (int i = 0; i < PlayerProfile.player.money.Length; i++)       
            moneyPlayer.money[i] = PlayerProfile.player.money[i];
        
        //Wenn der Stack kleiner ist als unsere Sales (Abnehmermenge) --> Verkaufe ganze Stack
        if (!moneyCalculator.EnoughMoney(stack, sales))
        {
            moneyCalculator.AddMoney(moneyPlayer, stack);
            stack = new Money();
        }
        //Sonst verringere den Stack um die Sales (Abnehmermenge) und erhöhe das Spieler Geld um die Sales
        else
        {
            moneyCalculator.SubMoney(stack, sales);
            moneyCalculator.AddMoney(moneyPlayer, sales);
        }

        //Money an den Spieler übertragen
        for (int i = 0; i < PlayerProfile.player.money.Length; i++)       
            PlayerProfile.player.money[i] = moneyPlayer.money[i];         
    }

    public Money GetUpgradeCosts()
    {
        Money m = new Money();
        int faktor = level / 50;
        m.money[faktor] = 200 * level + (455*level/37);
        Money mZero = new Money();
        moneyCalculator.AddMoney(m, mZero);
        return m;
    }

}
