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
        private bool CanAttack => this.ReadyToAttack && target != null;
        private bool ReadyToAttack => this._elapsedTime > towerData.attackSpeed;

        private void Start(){
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
            
            if (targets.Count >0 && target == null) 
                UpdateTarget();
            
            if (this.CanAttack) 
                Attack();
        }

        public void UpdateTime() {
            this._elapsedTime += Time.deltaTime;
        }

        public void Attack() {
            var instance = Instantiate(towerData.projectilePrefab, this.transform.position, quaternion.identity, this.transform);
            var projectile = instance.GetComponent<Projectile>();
            
            //seems like the message system is too slow. also problems with messages from other towers.
            //better set the properties directly.
            //EventBroker.Instance().SendMessage(new EventSpawnBullet(this.transform, true, target.transform, towerData.projectileSpeed, towerData.damage));
            projectile.to = target.transform;
            projectile.speed = towerData.projectileSpeed;
            projectile.damage = towerData.damage;
            projectile.move = true;
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