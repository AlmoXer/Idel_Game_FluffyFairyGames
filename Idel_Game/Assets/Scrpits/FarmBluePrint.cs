using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class FarmBluePrint
    {
    [Header("Generell")]
    public GameObject prefab;
    public int cost;

    [Header("Forschung")]
    public int KostenGeld;
    public int vorausgesetztesLevel;

    [Header("UI")]
    public Sprite Icon;

    public int GetSellAmount()
    {
        return cost / 2;
    }

}