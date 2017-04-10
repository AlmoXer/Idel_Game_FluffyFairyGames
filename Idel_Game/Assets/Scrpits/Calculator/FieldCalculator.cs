using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCalculator : MonoBehaviour {

    public int[] nextFieldPoint;

    private int fields = 0;

    public int GetFields(int _Level)
    {
        fields = 0;
        if (_Level> 0)
        {
            do
                if (nextFieldPoint[fields] <= _Level)
                    fields++;
            while (_Level > nextFieldPoint[fields]);
            return fields;
        }

        return 0;
    }
}
