using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmBuilder : MonoBehaviour {

    public static FarmBuilder instance;

    public Farm[] farms;

    int lastButtonID = -1;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one FarmBuilder in scene!");
            return;
        }
        instance = this;
/*
        for (int i = 0; i < farms.Length; i++)
        {
          farms[i].ID = PlayerProfile.player.farmIDs[i];
          farms[i].level = PlayerProfile.player.farmLevels[i];
        }
        */
    }

    public void SetFarmID( int _ID)
    {
        lastButtonID = _ID;
    }

    public void BuildFarm(Image _image )
    {
        farms[lastButtonID].ID = FarmArchiv.instance.GetPositionOfIcon(_image.sprite);
        PlayerProfile.player.farmIDs[lastButtonID] = farms[lastButtonID].ID;
        PlayerProfile.player.farmLevels[lastButtonID] = 1;
        lastButtonID = -1;
    }
}
