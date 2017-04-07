using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TractorUI : MonoBehaviour {

    public Tractor tractor;
    public Image icon;
    private int ID=-1;
	// Update is called once per frame
	void Update () {
		if(tractor.ID!=ID)
        {
            ID = tractor.ID;
            icon.sprite = TractorArchiv.instance.allTraktors[tractor.ID].icon;
           
        }

	}
}
