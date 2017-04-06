using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeFarmCalculator : MonoBehaviour {

    public Money[] incomeFarm;
    public int[] faktorFarm;
    [SerializeField]
    private Money money = new Money();

    public Money GetIncome(int _ID, int _Level, int _Fields)
    {
        if( _ID >= 0 && _ID <= incomeFarm.Length)
        {

            for (int i = 0; i < money.money.Length; i++)
            {
                money.money[i] = (incomeFarm[_ID].money[i] * _Fields + _Level * incomeFarm[_ID].money[i]) * faktorFarm[_ID];
            }        

            return (money);
        }

        return null;
    }
}
