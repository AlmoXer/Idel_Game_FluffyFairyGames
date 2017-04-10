using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsCityUI : MonoBehaviour {

    public City city;
    public Button upgradeButton;
    private MoneyCalculator moneyCalculator;

    public Image iconCity;
    public Text levelCity;
    public Text sales;
    public Text helicopterSpeed;
    public Text salesDifference;
    public Text helicopterSpeedDifference;

    public Text costUpgrade;

    // Use this for initialization
    void Awake () {
        
        moneyCalculator = this.GetComponent<MoneyCalculator>();
        //UpdateData();
    }

    private void Update()
    {
        if (city == null)
            return;

        if (moneyCalculator.EnoughMoney(PlayerProfile.playerProfile.GetMoney(), city.GetUpgradeCosts()) && city.level != city.levelMax)
            upgradeButton.GetComponent<Button>().interactable = true;
        else
            upgradeButton.GetComponent<Button>().interactable = false;
    }

    public void UpdateData()
    {

        iconCity.sprite = GameObject.FindObjectOfType<CityUI>().icon.sprite;
        levelCity.text = city.level.ToString();

        // Sales(Abnehmermenge) alle 5 Sekungen
        sales.text = moneyCalculator.GetMoneyString(city.sales);
        salesDifference.text = moneyCalculator.GetMoneyString(city.GetDifference());

        helicopterSpeed.text = GameObject.FindObjectOfType<Helicopter>().speed.ToString();
        helicopterSpeedDifference.text = GameObject.FindObjectOfType<Helicopter>().GetDifferenceSpeed().ToString();
        costUpgrade.text = moneyCalculator.GetMoneyString(city.GetUpgradeCosts());
                  
    }

}
