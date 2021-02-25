using System.Collections.Generic;
using UnityEngine;

namespace Enemy{
    public class EnemyUnit : MonoBehaviour, IEnemyUnit{
        public EnemyUnitData unit;
        public void SetUp(){
            this.gameObject.name = unit.name;
            this._health = unit.health;
            this.transform.GetComponent<SpriteRenderer>().sprite = unit.mainTexture;
        }
        private float _health;
        public float Health{
            get => _health;
            set => _health = value;
        }
        public bool IsDead => this.Health <= 0f;

        public void Move(List<Vector3> waypointList){
            // use to move through any given list?
        }

        public void Spawn(List<Vector3> spawningPointsList){
            // select random spawnpoint, spawn point has a list of waypoints?
        }

        public void TakeDamage(float damage){
            this.Health -= damage;
            if (this.IsDead) {
                Destroy(this.gameObject);
            }
        }

    }
}
