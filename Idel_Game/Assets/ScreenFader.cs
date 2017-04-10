using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFader : MonoBehaviour {

    public GameObject farmDetails;
    public GameObject farmBuilder;
    public GameObject incomeOffline;
    public GameObject cityDetails;

    [SerializeField]
    private GameObject lastScreen;

    public void FarmClicked(Image _image)
    {
        if (FarmArchiv.instance.GetPositionOfIcon(_image.sprite) == -1)
            OpenFarmBuilder();
        else
            OpenFarmDetails();
    }

    public void OpenIncomeOffline()
    {
        incomeOffline.SetActive(true);
        lastScreen = incomeOffline;
    }

    public void OpenFarmDetails()
    {
        farmDetails.SetActive(true);
        lastScreen = farmDetails;
    }

    public void OpenFarmBuilder()
    {
        farmBuilder.SetActive(true);
        lastScreen = farmBuilder;
    }

    public void OpenCityDetails()
    {
        cityDetails.SetActive(true);
        lastScreen = cityDetails;
    }

    public void CloseLastScreen()
    {
        lastScreen.SetActive(false);
        lastScreen = null;
    }
}
