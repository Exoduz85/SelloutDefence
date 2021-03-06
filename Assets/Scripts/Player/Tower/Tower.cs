using System.Collections.Generic;
using System.Linq;
using Core;
using Enemy;
using EventBrokerFolder;
using Unity.Mathematics;
using UnityEngine;

namespace Player.Tower {
    public class Tower : MonoBehaviour, ITower {
        [SerializeField]
        public UpgradableTowerData towerData;

        [SerializeField]
        private List<GameObject> targets = new List<GameObject>();

        [SerializeField]
        private GameObject target;

        private float _elapsedTime;
        private bool CanAttack => this.ReadyToAttack && target != null;
        private bool ReadyToAttack => this._elapsedTime > towerData.TowerSpeed();

        private void Start(){
            SetUp(towerData);
        }

        public void SetUp(UpgradableTowerData towerData) {
            this.towerData = towerData;
            this.gameObject.AddComponent<SphereCollider>().radius = towerData.towerData.attackRange;
            this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }

        private void Update() {
            UpdateTime();

            RemoveDeadEnemies();
            
            if (targets.Count >0 && target == null) 
                UpdateTarget();
            
            if (this.CanAttack) 
                Attack();
        }

        private void RemoveDeadEnemies(){
            for (var i = targets.Count - 1; i >= 0; i--){
                if (targets[i] == null){
                    targets.Remove(targets[i]);
                }
            }
        }

        public void UpdateTime() {
            this._elapsedTime += Time.deltaTime;
        }

        public void Attack() {
            var instance = Instantiate(towerData.towerData.projectilePrefab, this.transform.position, quaternion.identity, this.transform);
            var projectile = instance.GetComponent<Projectile>();
            projectile.StartMove(target.transform, towerData.towerData.projectileSpeed, towerData.TowerDamage(), true);
            this._elapsedTime = 0;
        }

        void UpdateTarget() {
            this.target = targets.OrderBy(currentTarget =>
                (currentTarget.transform.position - this.transform.position).sqrMagnitude).FirstOrDefault();
        }

        public void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Enemy")) {
                targets.Add(other.gameObject);
            }
        }

        public void OnTriggerExit(Collider other) {
            if (!other.CompareTag("Enemy")) 
                return;
            
            if (target != null && other.gameObject == this.target.gameObject) {
                this.target = null;
            }

            targets.Remove(other.gameObject);
        }
    }
}