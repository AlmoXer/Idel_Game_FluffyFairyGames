using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmArchiv : MonoBehaviour {

    public static FarmArchiv instance;

    public FarmBluePrint[] allFarms;

    public Dictionary<int, FarmBluePrint> allBulltes = new Dictionary<int, FarmBluePrint>();


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one ProjektilArchiv in scene!");
            return;
        }
        instance = this;

        for (int i = 0; i < allFarms.Length; i++)
        {
            allBulltes.Add(i, allFarms[i]);
        }
    }

    public int GetPositionOfIcon(Sprite vergleichsSprite)
    {
        for (int i = 0; i < allBulltes.Count; i++)
        {
            if (allBulltes[i].Icon == vergleichsSprite)
                return i;
        }
        return -1;
    }

}
