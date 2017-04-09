using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldBuilder : MonoBehaviour {

    public Farm farm;
    private Field field;
    private int countfields;
    private float buttonWidth;
    private float buttonHeight;
    private int level;
    public Field prefab;


	// Use this for initialization
	void Start () {
        countfields = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(level!=farm.level)
        {
            level = farm.level;

            GameObject[] allfields = GameObject.FindGameObjectsWithTag("Field");
            for (int i = 0; i < allfields.Length; i++)
            {
                int farmID = allfields[i].GetComponent<Field>().farmID;
                if (farmID == farm.POS)
                {
                    allfields[i].GetComponent<Field>().level = farm.level;                
                }
            }
        }

        if(farm.countFields != countfields)
        {
            RectTransform myRect = GetComponent<RectTransform>();
            buttonHeight = 30;
            buttonWidth = 30;
            GridLayoutGroup grid = this.GetComponent<GridLayoutGroup>();
            grid.cellSize = new Vector2(buttonWidth, buttonHeight);


            field = (Field)Instantiate(prefab);
            field.transform.SetParent(transform, false);

            field.ID = farm.ID;
            field.farmID = farm.POS;
            field.level = farm.level;
            field.GetComponent<FieldUI>().icon.sprite = FieldArchiv.instance.allFields[farm.ID].stage[0];
            countfields++;
            farm.tractor.SetActive(true);
        }
      

    }
	
}


