using System.Linq;
using EnemyWaypoints;
using UnityEngine;

namespace Enemy{
    public class MoveEnemy : MonoBehaviour{
        [SerializeField]private WaypointsPath waypointPath;
        [HideInInspector] public float speed = 10;
    
        private Transform[] waypoints;
        private int currentWaypoint = 1;
    
        private float initalTimer = 0.5f;
    
        void Start(){
            FindWaypoints();
        }
        
        void Update(){
            if (Time.time < initalTimer)
                return;
        
            MoveToNextWaypoint();
        }
        
        private void FindWaypoints(){
            //find the Waypoints parent gameobject that has the same path as this enemy type.
            var waypointList = FindObjectsOfType<Waypoints>().ToList();
            waypointList = waypointList.FindAll(waypoint => waypoint.waypointsPath == this.waypointPath);
            if (waypointList.Count == 0)
                return;
            
            //get all the waypoints from that list, to traverse by the enemy
            waypoints = waypointList.First().GetComponentsInChildren<Transform>();
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
