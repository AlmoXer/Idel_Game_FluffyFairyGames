using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldArchiv : MonoBehaviour {

    public static FieldArchiv instance;

    public FieldBluePrint[] fields;

    public Dictionary<int, FieldBluePrint> allFields = new Dictionary<int, FieldBluePrint>();

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one FieldArchiv in scene!");
            return;
        }
        instance = this;

        for (int i = 0; i < fields.Length; i++)
        {
            allFields.Add(i, fields[i]);
        }
    }

}
