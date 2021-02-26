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

        private float elapsedTime;
        private bool CanAttack => !this.IsChargingAttack && target != null;
        bool IsChargingAttack => this.elapsedTime < towerData.attackSpeed;

        public void SetUp(TowerData towerData) {
            this.towerData = towerData;
            this.gameObject.AddComponent<SpriteRenderer>().sprite = towerData.mainSprite;
            this.gameObject.AddComponent<SphereCollider>().radius = towerData.attackRange;
            this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }

        private void Update() {
            UpdateTime();
            if (target == null) UpdateTarget();
            if (this.CanAttack) {
                Attack();
            }
        }

        public void UpdateTime() {
            this.elapsedTime += Time.deltaTime;
        }

        public void Attack() {
            Instantiate(towerData.projectilePrefab, this.transform.position, quaternion.identity, this.transform);
            EventBroker.Instance().SendMessage(new EventSpawnBullet(true, target.transform.position, towerData.projectileSpeed, towerData.damage));
            this.elapsedTime -= towerData.attackRange;
        }

        void UpdateTarget() {
            if (targets == null) return;
            this.target = targets.OrderBy(target =>
                (target.transform.position - this.transform.position).sqrMagnitude).FirstOrDefault();
        }

        public void OnTriggerEnter(Collider other) {
            if (other.GetComponent<Targetable>()) {
                targets.Add(other.GetComponent<Targetable>().thisGuy);
            }
        }

        public void OnTriggerExit(Collider other) {
            if (!other.GetComponent<Targetable>()) return;
            if (other.gameObject == this.target.gameObject) {
                this.target = null;
            }

            targets.Remove(other.gameObject);
        }
    }
}