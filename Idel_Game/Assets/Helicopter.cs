using System.Collections;
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

    public void LoadCharge(GameObject _fieldObject)
    {
       // moneyCalculator.AddMoney(charge, _fieldObject.GetComponent<Field>().stack);
      //  _fieldObject.GetComponent<Field>().stack = new Money();
    }

    public void UnloadCharge()
    {
     //   moneyCalculator.AddMoney(farm.stack, charge);
        charge = new Money();
    }
}
