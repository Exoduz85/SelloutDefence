using UnityEngine;

namespace Enemy{
    [CreateAssetMenu(fileName = "EnemyUnit", menuName = "EnemyObjects/New enemy unit")]
    public class EnemyUnitData : ScriptableObject{
        public Sprite mainTexture;
        public float health;
        // add path? list<Vector3> waypointList?
        // add spawning point? list<Vector3> spawningPoint?
        // add speed?
        // add event?
    }
}