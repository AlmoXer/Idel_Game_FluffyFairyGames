using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelicopterUI : MonoBehaviour {

    public Animation animatonWork;
    public Helicopter helicopoter;
    private bool load = false;

    void Update()
    {
        if (helicopoter.idel)
        {
            return;
        }

        if(!helicopoter.load && load)
        {
            foreach (AnimationState state in animatonWork)
            {
                state.speed = 1.0f;
            }
            load = false;
        }
    }

}
