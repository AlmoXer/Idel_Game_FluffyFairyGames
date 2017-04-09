﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    public GameObject home;
    public float speed = 5.0F;
    public Money charge = new Money();
    private MoneyCalculator moneyCalculator;


    private void Start()
    {
        moneyCalculator = this.GetComponent<MoneyCalculator>();
    }

    public void LoadCharge(GameObject _helipadObject)
    {
        Helipad pad = _helipadObject.GetComponent<Helipad>();
        moneyCalculator.AddMoney(charge, pad.farm.stack);
        _helipadObject.GetComponent<Helipad>().farm.stack = new Money();
    }

    public void UnloadCharge()
    {
        City city = FindObjectOfType<City>();
       // moneyCalculator.AddMoney(city.stack, charge);
        charge = new Money();
    }
}
