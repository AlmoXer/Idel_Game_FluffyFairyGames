using UnityEngine;
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
    private RectTransform target;

    [SerializeField]
    private int countActiveWayPoints;

    void Start()
    {

        tractor = this.GetComponent<Tractor>();
    }

    void Update()
    {
        GameObject[] allfields = GameObject.FindGameObjectsWithTag("Field");
        GameObject[] waypoints = new GameObject[14];


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

        if (waypoints[0] != null)
        {
            iCount = 0;
            foreach (GameObject item in waypoints)
            {
                if (iCount == wavepointIndex)
                    target = item.GetComponent<RectTransform>();
                iCount++;
            }
        }
        if(target != null)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * tractor.speed * Time.deltaTime, Space.World);


            if (Vector3.Distance(transform.position, target.position) <= 3f)
            {
                 EndPath();
                 return;
             }
        }

        



    }

    void GetNextWaypoint()
    {
        /*  if (wavepointIndex >= wayPoints.points.Length - 1)
          {
              EndPath();
              return;
          }
          wavepointIndex++;
          target = wayPoints.points[wavepointIndex];
          Traktor.partToRotate.LookAt(target);
          */
    }

    void EndPath()
    {
        target = tractor.farm.GetComponent<RectTransform>();
    }
}