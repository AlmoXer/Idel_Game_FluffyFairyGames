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

    public int geld = 0;
    public int offlineTime;

    public int[] farmIDs = new int[6];



}

