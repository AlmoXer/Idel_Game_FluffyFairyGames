using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorArchiv : MonoBehaviour {

    public static TractorArchiv instance;

    public TractorBluePrint[] traktors;

    public Dictionary<int, TractorBluePrint> allTraktors = new Dictionary<int, TractorBluePrint>();


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
