using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmIteamUI : MonoBehaviour {

    public Image icon;
    public Text cost;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Aktuallisieren(Sprite _icon)
    {
        icon.sprite = _icon;
    }
}
