using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Tractor))]
public class HelicopterMovement : MonoBehaviour
{
    private int wavepointIndex = 0;
    private Helicopter helicopter;
    [SerializeField]
    private RectTransform target = new RectTransform();

    GameObject[] waypoints = new GameObject[7];

    [SerializeField]
    private int countActiveWayPoints;
    private bool driveHome = true;
    private bool load = false;

    private GameObject[] allHelipads;

    private float loadRate = 1.18f;
    private float loadCountDown = 1.18f;

    void Start()
    {
        helicopter = this.GetComponent<Helicopter>();

       allHelipads = GameObject.FindGameObjectsWithTag("Helipad");
        target = helicopter.home.GetComponent<RectTransform>();
    }

    void Update()
    {
        allHelipads = GameObject.FindGameObjectsWithTag("Helipad");


        if (allHelipads.Length == 0)
        {
            helicopter.idel = true;
            return;
        }
        else
            helicopter.idel = false;

        if (target == null)
            target = helicopter.home.GetComponent<RectTransform>();

        countActiveWayPoints = 0;
        int iCount = 0;
        for (int i = 0; i < allHelipads.Length; i++)
        {
            int farmID = allHelipads[i].GetComponent<Helipad>().ID;

            waypoints[farmID] = allHelipads[i];
            iCount++;
            
        }

        countActiveWayPoints = iCount + 1;

        for (int i = 0; i < (countActiveWayPoints-1); i++)
        {
            if(waypoints[i] == null)
            {
                for (int j = i; j < waypoints.Length-1; j++)
                {
                    waypoints[j] = waypoints[j + 1];
                }
                //Wenn immer noch Null erneut durchlaufen
                if (waypoints[i] == null && i != (countActiveWayPoints - 1))
                    i--;
                bool empty = true;
                for (int j = i; j < waypoints.Length - 1; j++)               
                    if (waypoints[j] != null)
                        empty =false;
                if (empty)
                    break;
                
            }
        }

      

        if (target != null)
        {
            if (!load)
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * helicopter.speed * Time.deltaTime, Space.World);


                if (Vector3.Distance(transform.position, target.position) <= 0.5f)
                {

                    if (driveHome)
                    {
                        wavepointIndex = -1;
                        helicopter.UnloadCharge();
                        loadCountDown = 100;
                    }

                    loadCountDown = loadRate;
                    load = true;
                    helicopter.load = true;

                }
            }
        }



        if (loadCountDown <= 0f && load)
        {
            load = false;
            helicopter.load = false;
            if (!driveHome)
                helicopter.LoadCharge(waypoints[wavepointIndex]);

            GetNextWaypoint();


        }

        if (load)
            loadCountDown -= Time.deltaTime;

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= countActiveWayPoints - 2)
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
        target = helicopter.home.GetComponent<RectTransform>();
        driveHome = true;
    }


}
