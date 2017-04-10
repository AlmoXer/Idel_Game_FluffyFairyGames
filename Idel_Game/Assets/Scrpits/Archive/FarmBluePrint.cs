using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class FarmBluePrint
    {
    [Header("Generell")]
    public GameObject prefab;
    public Money cost;
    public string name = "Farm";

    [Header("UI")]
    public Sprite Icon;

   /* public int GetSellAmount()
    {
        return cost / 2;
    }*/

}