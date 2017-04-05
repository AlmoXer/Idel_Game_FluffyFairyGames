using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFader : MonoBehaviour {

    public GameObject farmDetails;
    public GameObject farmBuilder;

    [SerializeField]
    private GameObject lastScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FarmClicked(Image _image)
    {
        if (FarmArchiv.instance.GetPositionOfIcon(_image.sprite) == -1)
            OpenFarmBuilder();
        else
            OpenFarmBuilder();
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

    public void CloseLastScreen()
    {
        lastScreen.SetActive(false);
        lastScreen = null;
    }
}
