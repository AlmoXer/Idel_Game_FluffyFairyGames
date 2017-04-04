using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmArchiv : MonoBehaviour {

    public static FarmArchiv instance;

    public FarmBluePrint[] farms;

    public Dictionary<int, FarmBluePrint> allFarmes = new Dictionary<int, FarmBluePrint>();


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one ProjektilArchiv in scene!");
            return;
        }
        instance = this;

        for (int i = 0; i < farms.Length; i++)
        {
            allFarmes.Add(i, farms[i]);
        }
    }

    public int GetPositionOfIcon(Sprite vergleichsSprite)
    {
        for (int i = 0; i < allFarmes.Count; i++)
        {
            if (allFarmes[i].Icon == vergleichsSprite)
                return i;
        }
        return -1;
    }

}
