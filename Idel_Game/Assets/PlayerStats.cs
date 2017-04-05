using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public Text incomeOffline;
    public Text incomeOnline;
    public Text money;
    public Text rank;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update () {

        incomeOffline.text = PlayerProfile.player.incomeOffline.ToString() + "/s";
        incomeOnline.text = PlayerProfile.player.incomeOnline.ToString() + "/s";
        money.text = PlayerProfile.player.money.ToString();
        rank.text = PlayerProfile.player.rank;
    }

   
}
