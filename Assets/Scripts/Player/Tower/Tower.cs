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
        private TowerData towerData;

        [SerializeField]
        private List<GameObject> targets = new List<GameObject>();

        [SerializeField]
        private GameObject target;

        private float _elapsedTime;
        private bool _isTargetNull;
        private bool CanAttack => this.ReadyToAttack && target != null;
        private bool ReadyToAttack => this._elapsedTime > towerData.attackSpeed;

        private void Start(){
            _isTargetNull = target == null;
            SetUp(towerData);
        }

        public void SetUp(TowerData towerData) {
            this.towerData = towerData;
            this.gameObject.AddComponent<SpriteRenderer>().sprite = towerData.mainSprite;
            this.gameObject.AddComponent<SphereCollider>().radius = towerData.attackRange;
            this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }

        private void Update() {
            UpdateTime();
            
            if (targets != null && _isTargetNull) 
                UpdateTarget();
            
            if (this.CanAttack) 
                Attack();
        }

        public void UpdateTime() {
            this._elapsedTime += Time.deltaTime;
        }

        public void Attack() {
            Instantiate(towerData.projectilePrefab, this.transform.position, quaternion.identity, this.transform);
            EventBroker.Instance().SendMessage(new EventSpawnBullet(true, target.transform.position, towerData.projectileSpeed, towerData.damage));
            this._elapsedTime -= towerData.attackRange;
        }

        void UpdateTarget() {
            this.target = targets.OrderBy(currentTarget =>
                (currentTarget.transform.position - this.transform.position).sqrMagnitude).FirstOrDefault();
        }

        public void OnTriggerEnter(Collider other) {
            Debug.Log("enemy detected");
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