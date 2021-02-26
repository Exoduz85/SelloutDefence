using UnityEngine;

namespace EnemyWaypoints{
    public class Waypoints : MonoBehaviour{
        [SerializeField] public WaypointsPath waypointsPath;


        private void OnDrawGizmos(){
            var children = GetComponentsInChildren<Transform>();
            Color color = Color.black;
            if (this.waypointsPath.pathtype == WaypointsPath.PathType.PathA){
                color = Color.green;
            }
            
            if (this.waypointsPath.pathtype == WaypointsPath.PathType.PathB){
                color = Color.blue;
            }
            
            if (this.waypointsPath.pathtype == WaypointsPath.PathType.PathC){
                color = Color.red;
            }
                
            for (var i = 0; i < children.Length-1; i++){
                Debug.DrawLine(children[i].position, children[i+1].position, color);
            }
        }
    }
}
