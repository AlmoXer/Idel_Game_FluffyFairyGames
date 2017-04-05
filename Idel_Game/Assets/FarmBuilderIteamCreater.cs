using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmBuilderIteamCreater : MonoBehaviour
{


    private float buttonWidth;
    private float buttonHeight;
    public Image prefab;
    private Image image;

    void Start()
    {
        RectTransform myRect = GetComponent<RectTransform>();
        buttonHeight = 70;
        buttonWidth = 70;
        GridLayoutGroup grid = this.GetComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(buttonWidth, buttonHeight);


        for (int i = 0; i < FarmArchiv.instance.allFarmes.Count; i++)
        {

            image = Instantiate(prefab);
            image.transform.SetParent(transform, false);

            image.GetComponent<FarmIteamUI>().Aktuallisieren(FarmArchiv.instance.allFarmes[i].Icon);
           
        }
    }
}
