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

        //Income Offline Anzeigen
        for (int i = PlayerProfile.player.incomeOffline.Length - 1; i >= 0; i--)
        {
            if (i == 0)
                Debug.Log("");

            if (PlayerProfile.player.incomeOffline[i] > 0)
            {
                string text;
                if (i > 0)
                    text = PlayerProfile.player.incomeOffline[i].ToString() + "." + (PlayerProfile.player.incomeOffline[i - 1] / 10).ToString() + " " + (char)(i + 97);
                else
                    text = PlayerProfile.player.incomeOffline[i].ToString() + " " + (char)(i + 97);


                incomeOffline.text = text;
                break;
            }
        }

        //Income Online Anzeigen
        for (int i = PlayerProfile.player.incomeOnline.Length - 1; i >= 0; i--)
        {
            if (PlayerProfile.player.incomeOnline[i] > 0)
            {
                string text;
                if (i > 0)
                    text = PlayerProfile.player.incomeOnline[i].ToString() + "." + (PlayerProfile.player.incomeOnline[i - 1] / 10).ToString() + " " + (char)(i + 97) + "/s";
                else
                    text = PlayerProfile.player.incomeOnline[i].ToString() + " " + (char)(i + 97) + "/s";


                incomeOnline.text = text;
                break;
            }
        }


        //Geld Anzeigen
        for (int i = PlayerProfile.player.money.Length - 1; i >= 0; i--)
        {
            if (PlayerProfile.player.money[i] > 0)
            {
                string text;
                if (i > 0)
                    text = PlayerProfile.player.money[i].ToString() + "." + (PlayerProfile.player.money[i - 1] / 10).ToString() + " " + (char)(i + 97);
                else
                    text = PlayerProfile.player.money[i].ToString() + " " + (char)(i + 97);


                money.text = text;
                break;
            }

            if (i == 0)
                money.text = "Pleite";
        }

        //Titel Anzeigen
        rank.text = PlayerProfile.player.rank;
    }

   
}
