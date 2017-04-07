using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraktorArchiv : MonoBehaviour {

    public static TraktorArchiv instance;

    public TraktorBluePrint[] traktors;

    public Dictionary<int, TraktorBluePrint> allTraktors = new Dictionary<int, TraktorBluePrint>();


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one TraktorArchiv in scene!");
            return;
        }
        instance = this;

        for (int i = 0; i < traktors.Length; i++)
        {
            allTraktors.Add(i, traktors[i]);
        }
    }

}
