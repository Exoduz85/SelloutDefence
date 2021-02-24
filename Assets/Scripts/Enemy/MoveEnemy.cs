using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemy{
    public class MoveEnemy : MonoBehaviour{
        [SerializeField] private WaypointsPath waypointPath;
        [SerializeField]private float speed = 10;
    
        private Transform[] waypoints;
        private int currentWaypoint = 1;
    
        private float initalTimer = 1f;
    
        // Start is called before the first frame update
        void Start(){
            //find the Waypoints gameobject that has the same path as this enemy type.
            var waypointList = new List<Waypoints>();
            waypointList = FindObjectsOfType<Waypoints>().ToList();
            waypointList = waypointList.FindAll(waypoint => waypoint.waypointsPath == this.waypointPath);
            if (waypointList.Count == 0)
                return;
            
            //get all the waypoints from that list, to traverse by the enemy
            waypoints = waypointList.First().GetComponentsInChildren<Transform>();
        }

        // Update is called once per frame
        void Update(){
            if (Time.time < initalTimer)
                return;
        
            MoveToNextWaypoint();
        }

        private void MoveToNextWaypoint(){

            if (waypoints == null || currentWaypoint >= waypoints.Length)
                return;
        
            this.transform.position = Vector3.MoveTowards(this.transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        
            if (this.transform.position == waypoints[currentWaypoint].position){
                currentWaypoint++;
            }
        }
    }
}
