using UnityEngine;
using System.Collections;
public class Fanpath : MonoBehaviour
{
  
   public PathScript waveConigSpawn;
    private Transform[] waypoints;
    Rigidbody2D rb;
    private int waypointsIndex = 0;

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
        waypoints = waveConfigSpawn.GetWaypoints();
        transform.position = waveConfigSpawn.GetStartingWaypoint().position;
    }


    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        // Check if the enemy has reached the last waypoint
        if (waypointsIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointsIndex].position;
            float moveAmount = waveConfigSpawn.GetEnemyMoveSpeed() * Time.deltaTime;
            rb.MovePosition(Vector3.MoveTowards(transform.position, targetPosition, moveAmount));

            if (transform.position == targetPosition)
            {// Move to the next waypoint
                waypointsIndex++;
              
            }
        }
        else
        {// loop back to the first waypoint
            waypointsIndex = 0;
        }
    }
}
