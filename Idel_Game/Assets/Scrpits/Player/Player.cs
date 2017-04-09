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

    public int[] money = new int[27];
    public long offlineTime;
    public int[] incomeOffline = new int[27];
    public int[] incomeOnline = new int[27];


    public int[] farmIDs = new int[6];
    public int[] farmLevels = new int[6];

}

