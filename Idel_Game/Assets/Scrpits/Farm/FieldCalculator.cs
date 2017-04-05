using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCalculator : MonoBehaviour {

    public int[] nextFieldPoint;

    private int fields = 0;

    public int GetFields(int _Level)
    {
        if (_Level> 0)
        {
            if (nextFieldPoint[fields] == _Level)
                fields++;
            return fields;
        }

        return 0;
    }
}
