﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Tractor))]
public class TractorMovement : MonoBehaviour
{
    public GameObject fields;
    private int wavepointIndex = 0;
    // public Waypoints wayPoints;
    private Tractor tractor;
    [SerializeField]
    private RectTransform target = new RectTransform();

    GameObject[] waypoints = new GameObject[14];

    [SerializeField]
    private int countActiveWayPoints;
    private bool driveHome = false;
    void Start()
    {
        tractor = this.GetComponent<Tractor>();

        GameObject[] allfields = GameObject.FindGameObjectsWithTag("Field");
        int iCount;
        for (int i = 0; i < allfields.Length; i++)
        {
            int farmID = allfields[i].GetComponent<Field>().farmID;

            if (farmID == tractor.farm.POS)
            {
                target = allfields[i].GetComponent<RectTransform>();
                return;
            }
        }


    }

    void Update()
    {
        GameObject[] allfields = GameObject.FindGameObjectsWithTag("Field");

        int iCount = 0;
        for (int i = 0; i < allfields.Length; i++)
        {
            int farmID = allfields[i].GetComponent<Field>().farmID;

            if (farmID == tractor.farm.POS)
            {
                waypoints[iCount] = allfields[i];
                iCount++;
                countActiveWayPoints = iCount;              
            }
        }

        if(target != null)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * tractor.speed * Time.deltaTime, Space.World);


            if (Vector3.Distance(transform.position, target.position) <= 0.5f)
            {
                if (driveHome)
                    wavepointIndex = -1;
                
                GetNextWaypoint();
             }
        }

        



    }

    void GetNextWaypoint()
    {
          if (wavepointIndex >= countActiveWayPoints -1)
          {
              EndPath();
              return;
          }
          wavepointIndex++;
          target = waypoints[wavepointIndex].GetComponent<RectTransform>();
          driveHome = false;     
    }

    void EndPath()
    {
        target = tractor.farm.GetComponent<RectTransform>();
        driveHome = true;
    }


}