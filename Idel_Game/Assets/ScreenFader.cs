using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

    public GameObject farmDetails;
    [SerializeField]
    private GameObject lastScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenFarmDetails()
    {
        farmDetails.SetActive(true);
        lastScreen = farmDetails;
    }

    public void CloseLastScreen()
    {
        lastScreen.SetActive(false);
        lastScreen = null;
    }
}
