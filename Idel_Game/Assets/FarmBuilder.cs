using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmBuilder : MonoBehaviour {

    public Farm[] farms;

    int lastButtonID = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetFarmID( int _ID)
    {
        lastButtonID = _ID;
    }

    public void BuildFarm(Image _image )
    {
        farms[lastButtonID].ID = FarmArchiv.instance.GetPositionOfIcon(_image.sprite);
        lastButtonID = -1;
    }
}
