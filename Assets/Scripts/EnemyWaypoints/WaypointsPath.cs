using UnityEngine;

namespace EnemyWaypoints{
    
    [CreateAssetMenu]
    public class WaypointsPath : ScriptableObject
    {
        public enum PathType{PathA,
            PathB,
            PathC
        
        }
        [SerializeField] public PathType pathtype;
    }
}
