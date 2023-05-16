using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint2 : MonoBehaviour
{

    [Range(0f, 2f)]

    [SerializeField] private float waypointSize = 1f;


    [Header("Path Settings")]
    //sets the path to be looped so agent will go from last waypoint to the first or viceversa
    [SerializeField] private bool canLoop = true;


    //Sets the agent to move forward or backwards
    [SerializeField] private bool isMovingForward = true;


    private void OnDrawGizmos()
    {

      
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            //drawing gizmos
            Gizmos.DrawWireSphere(t.position, waypointSize);


        }
        //drawing a line between waypoints
        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            //              1st way point (i)=0             Second Point
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
        if (canLoop)

            //if the path is set to loop then draw a line between the last and first waypoint
            Gizmos.DrawLine(transform.GetChild(transform.childCount -1).position, transform.GetChild(0).position);

    }
    //will get the correct next waypoint based on the direction currently travelling

    //Agent will move from one point to another
    public Transform GetNextWaypoint(Transform currentWaypoint)
        {
            if (currentWaypoint == null)
            {
                 return transform.GetChild(0);
            }
            
            //stores the index of the current waypoint
            int currentIndex = currentWaypoint.GetSiblingIndex();

        //stores the index of the next waypoint to travel towards
            int nextIndex = currentIndex;
        //Agent is moving forward on the path
        if (isMovingForward)
        {
            nextIndex += 1;

            //If the next waypoint index is equal to the count of children/waypoints then it is already at the last waypoint
            //Check if the path is set to loop and return the first waypoint as the current waypoint otherwise we substract 1
            //from, nextIndex which will return the same waypoint that the agent is currently at,which will cause it to stop
            //moving since is already there
            if (nextIndex < transform.childCount)
            {
                if (canLoop)
                {
                    nextIndex = 0;
                }
                else
                {
                    nextIndex -= 1;
                }

            }
   


        }
        if (currentIndex < transform.childCount -1)
        {
            return transform.GetChild(currentIndex + 1);
        }

        //Agent is moving backwards on the path

        else
        {

            nextIndex -= 1;

            //If the nextIndex is below 0 then it means that you already are at the first waypoint, check if the path is set
            // to a loop and if so return the last waypoint, otherwise add 1 to the nextIndex ehich will return the curren
            //waypoint that you are already at which will cause the agent to stop since it is already there
            if (nextIndex < 0)
            {
                if (canLoop)
                {
                    nextIndex = transform.childCount - 1;

                }
                else
                {
                    nextIndex += 1;
                }


            }

        }

        //Return the waypoint that has an index of nextIndex
        return transform.GetChild(nextIndex);
            //if (currentIndex < transform.childCount - 1) 
            //{
            //     return transform.GetChild(currentIndex + 1);
            //}

            //else
            //{
            //if (canLoop)
            //{
            //    return transform.GetChild(0);
            //}
            //else
            //{
            //    return transform.GetChild(currentIndex);
            //}
                
            //}



    }
  
}
