using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CityUI : MonoBehaviour {

    public Sprite[] spritesCity;

    public Text levelText;
    public Text stackText;

    public Image icon;

    public City city;
    private int level = 0;

    public int[] levelUpBroder;

    private MoneyCalculator moneyCalculator;

    void Start()
    {
        moneyCalculator = this.GetComponent<MoneyCalculator>();
    }

    void Update()
    {
        stackText.text = moneyCalculator.GetMoneyString(city.stack);

        if (city.level!=level)
        {
            level = city.level;

            for (int i = 0; i < spritesCity.Length; i++)
            {
                if(level >= levelUpBroder[i] && level< levelUpBroder[i+1])
                {
                    icon.sprite = spritesCity[i];
                    return;
                }
            }
            
        }   

    }

}
