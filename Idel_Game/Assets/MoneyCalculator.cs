using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoneyCalculator : MonoBehaviour {

    private Money money = new Money();

    public Money GetMoneyOffline (Money _money, int DeltaTime)
    {
        for (int i = 0; i < money.money.Length; i++)
            money.money[i] = 0;

        for (int i = 0; i < money.money.Length; i++)
        {
            money.money[i] = _money.money[i] * DeltaTime;

            do {
                if (_money.money[i] > 1000)
                {
                    _money.money[i] -= 1000;
                    _money.money[i + 1]++;
                }
            }
            while (_money.money[i] > 1000) ;
        }

        return money;
    }

    void SubMoney(string _money, string _sub)
    {
        string stage = _money.Substring(_money.Length - 2);
        string stageSub = _sub.Substring(_sub.Length - 2);

        string money = _money.Substring(0, _money.Length - 3);
        string moneySub = _sub.Substring(0, _sub.Length - 3);
    }

    void addMoney(string _money, string _add)
    {
        string stage = _money.Substring(_money.Length - 2);
        string stageAdd = _add.Substring(_add.Length - 2);

        string money_s = _money.Substring(0, _money.Length - 3);
        string moneyAdd_s = _add.Substring(0, _add.Length - 3);

        int money = Int32.Parse(money_s);
        int moneyAdd = Int32.Parse(moneyAdd_s);


    }

    void AddMoney(Money _money, Money _add)
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
