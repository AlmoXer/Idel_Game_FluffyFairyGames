using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFader : MonoBehaviour {

    public GameObject farmDetails;
    public GameObject farmBuilder;
    public GameObject incomeOffline;
    public GameObject cityDetails;
    public GameObject[] farms;
    public GameObject city;
 
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
        deactivateMatchfield();
    }

    public void OpenFarmDetails()
    {
        farmDetails.SetActive(true);
        lastScreen = farmDetails;
        deactivateMatchfield();
    }

    public void OpenFarmBuilder()
    {
        farmBuilder.SetActive(true);
        lastScreen = farmBuilder;
        deactivateMatchfield();
    }

    public void OpenCityDetails()
    {
        cityDetails.SetActive(true);
        lastScreen = cityDetails;
        deactivateMatchfield();
    }

    public void CloseLastScreen()
    {
        lastScreen.SetActive(false);
        lastScreen = null;
        activateMatchfield();
    }

    void deactivateMatchfield()
    {
        city.GetComponent<Button>().interactable = false;
        for (int i = 0; i < farms.Length; i++)
        {
            farms[i].GetComponent<Button>().interactable = false;
        }
    }


    void activateMatchfield()
    {
        city.GetComponent<Button>().interactable = true;
        for (int i = 0; i < farms.Length; i++)
        {
            farms[i].GetComponent<Button>().interactable = true;
        }
    }
}
