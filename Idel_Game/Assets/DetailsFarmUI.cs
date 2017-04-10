using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsFarmUI : MonoBehaviour {

    public Text title;
    public Image iconFarm;
    public Text levelFram;

    public Text incomeOffline;
    public Text incomeOnline;
    public Text countFelder;

    public Text incomeOfflineDifference;
    public Text incomeOnlineDifference;
    public Text countFelderDifference;

    public Text costUpgrade;
    public GameObject upgradeButton;

    private MoneyCalculator moneyCalculator;
    private Farm farm;
    void Awake()
    {
        moneyCalculator = this.GetComponent<MoneyCalculator>();
    }


    private void Update()
    {
        if (farm == null)
            return;

        if (moneyCalculator.EnoughMoney(PlayerProfile.playerProfile.GetMoney(), farm.GetUpgradeCosts()))
            upgradeButton.GetComponent<Button>().interactable = true;
        else
            upgradeButton.GetComponent<Button>().interactable = false;

        if (farm.level.ToString() != levelFram.text)
            UpdateData();
    }

    public void UpdateData()
    {
        if (farm.ID != -1)
        {
            title.text = FarmArchiv.instance.allFarmes[farm.ID].name;

            iconFarm.sprite = FarmArchiv.instance.allFarmes[farm.ID].Icon;
            levelFram.text = farm.level.ToString();

            //Income Offline Anzeigen  
            incomeOffline.text = moneyCalculator.GetMoneyString(farm.incomeOffline);

            //Income Online Anzeigen
            incomeOnline.text = moneyCalculator.GetMoneyString(farm.incomeOnline);

            countFelder.text = farm.countFields.ToString();


            //Income OfflineDifference Anzeigen  
            incomeOfflineDifference.text = moneyCalculator.GetMoneyString(farm.GetDifferenceOffline());

            //Income OnlineDifference Anzeigen
            incomeOnlineDifference.text = moneyCalculator.GetMoneyString(farm.GetDifferenceOnline());

            countFelderDifference.text = farm.GetDifferenceFields().ToString();

            costUpgrade.text = moneyCalculator.GetMoneyString(farm.GetUpgradeCosts());

            upgradeButton.GetComponent<UpgradeFarmButton>().SetFarm(farm);


        }
    }

    public void SetUpdateData(Farm _farm)
    {
        farm = _farm;
        UpdateData();
        
    }

}
