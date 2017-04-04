using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmUI : MonoBehaviour
{

    public Text level;
    public Text geld;
    public Text forschung;
    public Image icon;
    private int farmID;
    public Button background;

    void Start()
    {
        farmID = FarmArchiv.instance.GetPositionOfIcon(icon.sprite); 
    }

    void Update()
    {
        if (farmID != -1)
        {
            level.text = FarmArchiv.instance.allBulltes[farmID].vorausgesetztesLevel.ToString();
            geld.text = FarmArchiv.instance.allBulltes[farmID].KostenGeld.ToString();

            /*
            bool done = false;
            if (!PlayerProfile.player.projektilTree[Position])
            {
                //Vorrausgesetztes Level Reicht nicht aus
                if (PlayerProfile.player.level < ProjektilArchiv.instance.allBulltes[Position].vorausgesetztesLevel)
                {
                    background.image.color = Color.red;
                    done = true;
                }
                //Nicht Genug Forschungspunkte oder Geld
                if ((PlayerProfile.player.geld < ProjektilArchiv.instance.allBulltes[Position].KostenGeld || PlayerProfile.player.forschung < ProjektilArchiv.instance.allBulltes[Position].KostenForschung) && !done)
                {
                    background.image.color = Color.red;
                    done = true;
                }
                //Kann Gekauft werden
                if (!done)
                    background.image.color = Color.yellow;
            }
            else
            {
                //Wurde Bereist Gekauft
                background.image.color = Color.green;
            }*/
        }

    }

    public void Aktuallisieren(Sprite _icon)
    {
        icon.sprite = _icon;
    }
}
