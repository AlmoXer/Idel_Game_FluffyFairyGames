using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farm : MonoBehaviour {

    //public Image icon;
    public int POS;
    public int ID = -1;
    public int level = 0;
    public int levelMax = 800;
    public int countFields = 0;
    public Money incomeOnline ;
    public Money incomeOffline ;
    private Money upgradeCost = new Money();
    public Money stack = new Money();

    public IncomeFarmCalculator incomeCalculator;
    public FieldCalculator fieldCalculator;
    public GameObject tractor;
    public GameObject helipad;

    public MoneyCalculator moneyCalculator;

    private void Start()
    {
        LoadStack();
        moneyCalculator = this.GetComponent<MoneyCalculator>();
        InvokeRepeating("SaveStack", 0f, 2.0f);

    }
    // Update is called once per frame
    void Update () {

        if (ID == -1)
        {
            tractor.SetActive(false);
            helipad.SetActive(false);
            return;
        }
        FieldCalculator();
        IncomeCalculator();
	}

    public void IncomeCalculator()
    {
        incomeOnline = incomeCalculator.GetIncome(ID, level, countFields);
        incomeOffline = incomeCalculator.GetIncomeOffline(ID, level, countFields);

        PlayerProfile.farmIncomes[POS] = incomeOnline;
    }

    public void FieldCalculator()
    {
        if(countFields != fieldCalculator.GetFields(level))
        {           
            countFields = fieldCalculator.GetFields(level);
        }
    }

    public Money GetUpgradeCosts()
    {
        Money m = new Money();
        int faktor = level / 50;
        m.money[faktor] = (200 * level) + (level * 455 / 37);
        Money mZero = new Money();
        moneyCalculator.AddMoney(m, mZero);   
        return m;
    }

    void SaveStack()
    {
        for (int j = 0; j < PlayerProfile.player.farmStack[POS].Length; j++)
        {
            PlayerProfile.player.farmStack[POS][j] = stack.money[j];
        }
    }

    void LoadStack()
    {
        for (int j = 0; j < PlayerProfile.player.farmStack[POS].Length; j++)
        {
            stack.money[j] = PlayerProfile.player.farmStack[POS][j];
        }
    }

    public Money GetDifferenceOffline() {
        Money diffOff = incomeCalculator.GetIncomeOffline(ID, level + 1 , countFields);
        Money moneyOff = incomeCalculator.GetIncomeOffline(ID, level , countFields);
        moneyCalculator.SubMoney(diffOff, moneyOff);
        return diffOff;
    }

    public Money GetDifferenceOnline()
    {
        Money diffOn = incomeCalculator.GetIncome(ID, level + 1, countFields);
        Money moneyOn= incomeCalculator.GetIncome(ID, level, countFields);
        moneyCalculator.SubMoney(diffOn, moneyOn);
        return diffOn;
    }

    public int GetDifferenceFields()
    {
        return fieldCalculator.GetFields(level + 1) - fieldCalculator.GetFields(level);
    }



}
