using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {

    public int level = 1;
    public int levelMax = 400;
    public Money sales = new Money();
    public Money stack = new Money();
    private Money moneyPlayer = new Money();
    private Money money = new Money();

    [HideInInspector]
    public MoneyCalculator moneyCalculator;

	// Use this for initialization
	void Start () {
        level = PlayerProfile.player.cityLevel;
        LoadStack();    
        moneyCalculator = this.GetComponent<MoneyCalculator>();
        InvokeRepeating("Sale", 0f, 5.0f);
        InvokeRepeating("SaveStack", 0f, 2.0f);

        sales.money[0] = sales.money[0]*level + (level * 100 / 455);
        Money mZero = new Money();
        moneyCalculator.AddMoney(sales, mZero);

        GameObject.FindObjectOfType<Helicopter>().UpdateSpeed();
    }
    
    void Sale()
    {
        //Wenn der Geld Stack in der Stadt leer ist --> Return 
        if (moneyCalculator.IsEmpty(stack))
            return;

        //Das (int[])Geld vom Spieler wird in eine Moneyklasse übertragen 
        for (int i = 0; i < PlayerProfile.player.money.Length; i++)       
            moneyPlayer.money[i] = PlayerProfile.player.money[i];
        
        //Wenn der Stack kleiner ist als unsere Sales (Abnehmermenge) --> Verkaufe ganzen Stack
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

    void SaveStack()
    {
        for (int j = 0; j < PlayerProfile.player.cityStack.Length; j++)
            PlayerProfile.player.cityStack[j] = stack.money[j];

    }

    void LoadStack()
    {
        for (int j = 0; j < PlayerProfile.player.cityStack.Length; j++)
            stack.money[j] = PlayerProfile.player.cityStack[j];

    }


}
