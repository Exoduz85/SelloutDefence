using System.Collections.Generic;
using UnityEngine;

namespace Enemy{
    
    public interface IEnemyUnit{
        public void Move(List<Vector3> waypointList);
        public void Spawn(List<Vector3> spawningPointsList);
        public void TakeDamage(float damage);
        public bool IsDead{ get; }
    }
}