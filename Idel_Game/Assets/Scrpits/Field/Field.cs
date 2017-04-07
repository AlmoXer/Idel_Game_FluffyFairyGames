using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

    public int status;
    public int ID = -1;

    private float updateRate = 2.5f;
    private float updateCountDown = 2.5f;

    void Update()
    {
        if (updateCountDown <= 0f)
        {
            NextStatus();
            updateCountDown = updateRate;
        }

        updateCountDown -= Time.deltaTime;
    }

    void NextStatus()
    {
        status++;
        if (status == 4)
            status = 0;
    }
}
