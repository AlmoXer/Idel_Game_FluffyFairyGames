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

    }

    public void SetFarmID( int _ID)
    {
        lastButtonID = _ID;
    }

    public void BuildFarm(Image _image )
    {
        farms[lastButtonID].ID = FarmArchiv.instance.GetPositionOfIcon(_image.sprite);
        farms[lastButtonID].level = 1;

        Money m = PlayerProfile.playerProfile.GetMoney();
        farms[farms[lastButtonID].ID].moneyCalculator.SubMoney(m, FarmArchiv.instance.farms[lastButtonID].cost);

        //Money an den Spieler übertragen
        for (int i = 0; i < PlayerProfile.player.money.Length; i++)
            PlayerProfile.player.money[i] = m.money[i];

        PlayerProfile.player.farmIDs[lastButtonID] = farms[lastButtonID].ID;
        PlayerProfile.player.farmLevels[lastButtonID] = 1;
        lastButtonID = -1;
    }
}
