using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class Player
{

    public Player() { }

    [XmlAttribute("name")]
    public string playerName = "Me";

    public string rank = "Landwirt";
    public int money = 0;
    public int offlineTime;
    public int incomeOffline;
    public int incomeOnline;


    public int[] farmIDs = new int[6];
    public int[] farmLevels = new int[6];

}

