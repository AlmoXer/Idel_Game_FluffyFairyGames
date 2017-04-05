using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeFarmCalculator : MonoBehaviour {

    public int[] incomeFarm;
    public int[] faktorFarm;

    public int GetIncome(int _ID, int _Level, int _Fields)
    {
        if( _ID >= 0 && _ID <= incomeFarm.Length)
        {
            return ((incomeFarm[_ID]*_Fields + _Level*incomeFarm[_ID])*faktorFarm[_ID]);
        }

        return 0;
    }
}
