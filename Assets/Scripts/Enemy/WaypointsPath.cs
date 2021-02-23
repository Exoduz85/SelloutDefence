using UnityEngine;

namespace Enemy{
    
    [CreateAssetMenu]
    public class WaypointsPath : ScriptableObject
    {
        public enum PathType{PathA,
            PathB,
            PathC
        
        }
        [SerializeField] private PathType pathtype;
    }
}
