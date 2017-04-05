using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmUI : MonoBehaviour {

    public Farm farm;
    public Image icon;
    public Text level;
    //public Image canUpgradeIcon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (farm.ID == -1)
            return;

        icon.sprite = FarmArchiv.instance.allFarmes[farm.ID].Icon;
	}
}
