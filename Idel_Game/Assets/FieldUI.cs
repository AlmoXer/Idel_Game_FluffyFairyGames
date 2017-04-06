using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FieldUI : MonoBehaviour {

    private Field field;
    public Image icon;

    private int status = 0;
 
    // Use this for initialization
    void Start () {
        field = FindObjectOfType<Field>();
	}

	void Update () {
        if(status!=field.status)
        {
            status = field.status;
            icon.sprite = FieldArchiv.instance.allFields[field.ID].stage[status];
        }
	}


}
