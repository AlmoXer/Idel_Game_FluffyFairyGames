using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farm : MonoBehaviour {

    //public Image icon;
    public int ID = -1;
    public int level = 0;
    public int countFields = 0;
    public static Money incomeOnline ;
    public static Money incomeOffline ;
    public IncomeFarmCalculator incomeCalculator;
    public FieldCalculator fieldCalculator;

	// Update is called once per frame
	void Update () {

        if (ID == -1)
            return;
        FieldCalculator();
        IncomeCalculator();
	}

    public void IncomeCalculator()
    {
        incomeOnline = incomeCalculator.GetIncome(ID, level, countFields);
        //incomeOffline = incomeOnline / 3;

        PlayerProfile.farmIncomes[ID] = incomeOnline;
    }

    public void FieldCalculator()
    {
        countFields = fieldCalculator.GetFields(level);
    }
}
