using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoneyCalculator : MonoBehaviour {

    private Money money = new Money();
    private Money earnOffline = new Money();

    public Money GetMoneyOffline (Money _money, int DeltaTime)
    {
        for (int i = 0; i < money.money.Length; i++)       
            money.money[i] = _money.money[i] * DeltaTime;
                         

        for (int i = 0; i < money.money.Length; i++)
        {
            do {
                if (money.money[i] > 1000)
                {
                    money.money[i] -= 1000;
                    money.money[i + 1]++;
                }
            }
            while (money.money[i] > 1000) ;
        }
        earnOffline = money;
        return money;
    }

    public void SetMoneyOffline()
    {
        for (int i = 0; i < PlayerProfile.player.money.Length; i++)
        {
            PlayerProfile.player.money[i] += earnOffline.money[i];
        }
        
    }

    public void AddMoney(Money _money, Money _add)
    {

        for (int i = 0; i < _money.money.Length; i++)
        {
            _money.money[i] += _add.money[i];
            do
            {
                if (_money.money[i] > 1000)
                {
                    _money.money[i] -= 1000;
                    _money.money[i + 1]++;
                }
            }
            while (_money.money[i] > 1000);
        }
       
    }

     
}
