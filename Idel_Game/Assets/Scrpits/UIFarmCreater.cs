using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFarmCreater : MonoBehaviour {

    private float iteamWidth;
    private float iteamHeight;
    public Button prefab;
    private Button button;

    void Start()
    {
        RectTransform myRect = GetComponent<RectTransform>();
        iteamHeight = 100;
        iteamWidth = 100;        
        GridLayoutGroup grid = this.GetComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iteamWidth, iteamHeight);


        for (int i = 0; i < FarmArchiv.instance.allBulltes.Count; i++)
        {

            button = (Button)Instantiate(prefab);
            button.transform.SetParent(transform, false);

            button.GetComponent<FarmUI>().Aktuallisieren(FarmArchiv.instance.allBulltes[i].Icon);

        }
    }
}
