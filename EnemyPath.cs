using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemyPath : MonoBehaviour
{
    public WayPointLine[] wayPointArray;

    public Transform[] wayPoints;


    public int currentPoint;
    private int endPoint;
    private bool atDestination;

    public float minDistance;
    public float speed;

    public UnityEvent attackEvent;

    private void Start()
    {
        endPoint = wayPoints.Length;
        //wayPoints = wayPointArray;
    }

    // Update is called once per frame
    void Update()
    {


        if (currentPoint == endPoint)
        {
            ResetArray();
            AttackEvent();
        }
        if (!atDestination)
        {
            float distance = Vector3.Distance(gameObject.transform.position, wayPoints[currentPoint].transform.position);
            if (distance > minDistance)
            {
                gameObject.transform.LookAt(wayPoints[currentPoint].transform.position);
                gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
            }
            else
            {
                Debug.Log(wayPoints[currentPoint]);
                currentPoint++;
            }
        }

    }

    void ResetArray()
    {
        currentPoint = 0;;
    }

    void AttackEvent()
    {
        attackEvent.Invoke();
        Debug.LogWarning("FinalPoint Bereikt", wayPoints[currentPoint]);
    }

}
