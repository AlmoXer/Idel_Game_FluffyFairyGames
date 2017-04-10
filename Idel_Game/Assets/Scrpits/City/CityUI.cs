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
    private int level = 1;

    public int[] levelUpBroder;

    private MoneyCalculator moneyCalculator;

    void Start()
    {
        icon.sprite = spritesCity[0];
        moneyCalculator = this.GetComponent<MoneyCalculator>();
    }

    void Update()
    {
        stackText.text = moneyCalculator.GetMoneyString(city.stack);

        if (city.level!=level)
        {
            level = city.level;
            levelText.text = level.ToString();

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
