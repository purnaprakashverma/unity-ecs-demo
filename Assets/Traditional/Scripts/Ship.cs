using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float pSpeed { get; private set; }
    public float pRotationSpeed { get; private set; }
    public int pCurrentWPIndex { get; private set; }

    private Transform mTarget = null;

    public void SetData(float speed, float rotationSpeed, int currentWayPointIndex)
    {
        pSpeed = speed;
        pRotationSpeed = rotationSpeed;
        pCurrentWPIndex = currentWayPointIndex;
        mTarget = DataManager.instance.waypoints[currentWayPointIndex];
    }

    private void Update()
    {
        if(mTarget)
        {
            //Vector3 heading = mTarget.position - transform.position;
            //Quaternion targetDirection = Quaternion.LookRotation(mTarget.position,Vector3.up);// (heading, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetDirection, Time.deltaTime * pRotationSpeed);
            //transform.position += Time.deltaTime * pSpeed * targetDirection.eulerAngles;
            transform.LookAt(mTarget.position);
            transform.position = Vector3.MoveTowards(transform.position, mTarget.position, Time.deltaTime * pSpeed);
            if (Vector3.Distance(transform.position, mTarget.position) < 10)
            {
                UpdateTarget();
            }
        }
    }

    private void UpdateTarget()
    {
        var waypointTransforms = DataManager.instance.waypoints;
        pCurrentWPIndex++;
        if (pCurrentWPIndex >= waypointTransforms.Length)
            pCurrentWPIndex = 0;
        mTarget = waypointTransforms[pCurrentWPIndex];
    }
}
