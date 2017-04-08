using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FieldUI : MonoBehaviour {

    public Field field;
    public Image icon;
    public Text stack;

    private int status = 0;

    void Update()
    {

        if (status != field.status)
        {
            status = field.status;
            icon.sprite = FieldArchiv.instance.allFields[field.ID].stage[status];

        }

        Money m = field.stack;

        for (int i = m.money.Length - 1; i >= 0; i--)
        {
            if (m.money[i] > 0)
            {
                string text;
                if (i > 0)
                    text = m.money[i].ToString() + "." + (PlayerProfile.player.incomeOffline[i - 1] / 10).ToString() + " " + (char)(i + 97);
                else
                    text = m.money[i].ToString() + " " + (char)(i + 97);


                stack.text = text;
                return;
            }
        }

        stack.text = "0 a";

    }

}
