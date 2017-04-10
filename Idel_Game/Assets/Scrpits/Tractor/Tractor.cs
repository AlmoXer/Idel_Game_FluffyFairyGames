using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MonoBehaviour {

    public Farm farm;
    public float speed;
    public Money charge = new Money();
    public int ID;

    public MoneyCalculator moneyCalculator;

    private void Update()
    {
        speed = 3f + 77f* (float)farm.level / (float)farm.levelMax;
    }

    public void LoadCharge(GameObject _fieldObject)
    {
        moneyCalculator.AddMoney(charge, _fieldObject.GetComponent<Field>().stack);
        _fieldObject.GetComponent<Field>().stack = new Money();
    }

    public void UnloadCharge()
    {
        moneyCalculator.AddMoney(farm.stack, charge);
        charge = new Money();
    }

    public float GetSpeedDifference()
    {
        return (3f + 77f * (float)(farm.level + 1) / (float)farm.levelMax) - (3f + 77f * (float)farm.level / (float)farm.levelMax);
    }
     
}
