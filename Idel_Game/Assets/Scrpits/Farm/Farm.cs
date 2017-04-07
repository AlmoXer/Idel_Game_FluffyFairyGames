using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farm : MonoBehaviour {

    //public Image icon;
    public int POS;
    public int ID = -1;
    public int level = 0;
    public int countFields = 0;
    public Money incomeOnline ;
    public Money incomeOffline ;
    public IncomeFarmCalculator incomeCalculator;
    public FieldCalculator fieldCalculator;
    public GameObject tractor;

	// Update is called once per frame
	void Update () {

        if (ID == -1)
        {
            tractor.SetActive(false);
            return;
        }
        FieldCalculator();
        IncomeCalculator();
	}

    public void IncomeCalculator()
    {
        incomeOnline = incomeCalculator.GetIncome(ID, level, countFields);
        PlayerProfile.farmIncomes[POS] = incomeOnline;
    }

    public void FieldCalculator()
    {
        if(countFields != fieldCalculator.GetFields(level))
        {           
            countFields = fieldCalculator.GetFields(level);
        }

    }
}
