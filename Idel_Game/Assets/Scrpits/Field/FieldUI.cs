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


        stack.text = field.moneyCalculator.GetMoneyString(field.stack);

        if(field.moneyCalculator.IsEmpty(field.stack))
        stack.text = "0 a";

    }

}
