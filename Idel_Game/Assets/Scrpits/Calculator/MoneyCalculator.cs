using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoneyCalculator : MonoBehaviour {

    private Money money = new Money();
    private Money earnOffline = new Money();
    private Money moneyPlayer = new Money();

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

        for (int i = 0; i < PlayerProfile.player.money.Length; i++)
                moneyPlayer.money[i] = PlayerProfile.player.money[i];

        for (int i = 0; i < moneyPlayer.money.Length; i++)
        {
            do
            {
                if (moneyPlayer.money[i] > 1000)
                {
                    moneyPlayer.money[i] -= 1000;
                    moneyPlayer.money[i + 1]++;
                }
            }
            while (moneyPlayer.money[i] > 1000);
        }

        for (int i = 0; i < PlayerProfile.player.money.Length; i++)
            PlayerProfile.player.money[i] = moneyPlayer.money[i] ;
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

    public void SubMoney(Money _money, Money _sub)
    {
        for (int i = 0; i < _money.money.Length; i++)
        {
            _money.money[i] -= _sub.money[i];
            if (_money.money[i] < 0)
            {
                _money.money[i+1]--;
                _money.money[i] += 1000;
            }

        }
    }

    public bool EnoughMoney(Money _money, Money _moneyComparative)
    {

        for (int i = _money.money.Length-1; i >= 0; i--)
        {
            if (_money.money[i] == _moneyComparative.money[i] && _money.money[i] == 0)
                continue;

            if (_money.money[i] < _moneyComparative.money[i])
                return false;

            if (_money.money[i] > _moneyComparative.money[i])
                return true;
            else
                continue;
            
        }

        return false;
    }

    public bool IsEmpty(Money _money)
    {
        for (int i = 0; i < _money.money.Length; i++)
        {
            if(_money.money[i]!=0)
                return false;
        }
        return true;
    }

    public string GetMoneyString(Money _money)
    {
        for (int i = _money.money.Length - 1; i >= 0; i--)
        {
            if (_money.money[i] > 0)
            {
                string text;
                if (i > 0)
                    text = _money.money[i].ToString() + "." + (_money.money[i - 1] / 10).ToString() + " " + (char)(i + 97);
                else
                    text = _money.money[i].ToString() + " " + (char)(i + 97);


                return text;
            }
        }
        return "00000a";
    }
}
