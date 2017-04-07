using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

    public int status;
    public int ID = -1;

    public int farmID = -1;

    private float updateRate = 2.5f;
    private float updateCountDown = 2.5f;

    public int level;

    [SerializeField]
    private Money income = new Money();
    public Money stack = new Money();

    public MoneyCalculator moneyCalculator;

    void Update()
    {
        if (updateCountDown <= 0f)
        {
            NextStatus();
            updateCountDown = updateRate;
        }

        updateCountDown -= Time.deltaTime;
    }

    void NextStatus()
    {
        status++;
        if (status == 4)
        {
            status = 0;
            UpdateIncome();
            moneyCalculator.AddMoney(stack, income);
        }
    }

    void UpdateIncome()
    {
        income.money[0] = (ID+5) * 3 * level * 10;
    }
}
