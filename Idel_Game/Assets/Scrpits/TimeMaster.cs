using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeMaster : MonoBehaviour {

    DateTime currentDate;
    DateTime oldDate;

    private int deltaTime;

    void Start()
    {
        //Store the current time when it starts
        currentDate = System.DateTime.Now;

        //Grab the old time from the player
        long temp = Convert.ToInt64(PlayerProfile.player.offlineTime);

        //Convert the old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);

        //Use the Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);

        deltaTime = difference.Days * 86400 + difference.Hours * 3600 + difference.Minutes * 60 + difference.Seconds;
    

    }

    public int GetDeltaTime()
    {
        return deltaTime;
    }
}
