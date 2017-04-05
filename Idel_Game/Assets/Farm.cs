using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farm : MonoBehaviour {

    //public Image icon;
    public int ID = -1;
    public int level = 0;
    public int countFields = 0;
    public int incomeOnline = 0;
    public int incomeOffline = 0;
    public IncomeFarmCalculator calculator;
	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {

        if (ID == -1)
            return;

        IncomeCalculator();
	}

    public void IncomeCalculator()
    {
        incomeOnline = calculator.GetIncome(ID, level, countFields);
        incomeOffline = incomeOnline / 3;

        PlayerProfile.farmIncomes[ID] = incomeOnline;
    }
}
