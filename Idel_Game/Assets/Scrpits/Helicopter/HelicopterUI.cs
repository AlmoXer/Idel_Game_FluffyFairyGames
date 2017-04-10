using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelicopterUI : MonoBehaviour {

    public Animator animator;
    public Helicopter helicopoter;
    private bool load = false;
    void Update()
    {
        if(helicopoter.load && !load)
        {
            animator.StopPlayback();
            load = true;
        }

        if(!helicopoter.load && load)
        {
            animator.StartPlayback();
            load = false;
        }
    }

}
