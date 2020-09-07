using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject[] wayPoints;
    public int currentPoint;
    private int endPoint;

    public float minDistance;
    public float speed;

    private void Start()
    {
        endPoint = wayPoints.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoint == endPoint)
        {
            ResetArray();
        }

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

    void ResetArray()
    {
        currentPoint = 0;;
    }
}
