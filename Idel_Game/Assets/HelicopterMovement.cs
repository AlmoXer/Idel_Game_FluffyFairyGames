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

    private float loadRate = 1.5f;
    private float loadCountDown = 1.5f;

    void Start()
    {
        helicopter = this.GetComponent<Helicopter>();

       allHelipads = GameObject.FindGameObjectsWithTag("Helipad");
        target = allHelipads[0].GetComponent<RectTransform>();
    }

    void Update()
    {
        allHelipads = GameObject.FindGameObjectsWithTag("Helipad");   
        countActiveWayPoints = allHelipads.Length +1;

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
                       // helicopter.UnloadCharge();
                        loadCountDown = 100;
                    }

                    loadCountDown = loadRate;
                    load = true;

                }
            }
        }



        if (loadCountDown <= 0f && load)
        {
            load = false;

            if (!driveHome)
                helicopter.LoadCharge(allHelipads[wavepointIndex]);

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
        target = allHelipads[wavepointIndex].GetComponent<RectTransform>();
        driveHome = false;


    }

    void EndPath()
    {
        target = helicopter.home.GetComponent<RectTransform>();
        driveHome = true;
    }


}
