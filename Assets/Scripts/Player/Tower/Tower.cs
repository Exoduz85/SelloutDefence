using System.Collections.Generic;
using System.Linq;
using Core;
using Enemy;
using EventBrokerFolder;
using Unity.Mathematics;
using UnityEngine;

namespace Player.Tower{
    public class Tower : MonoBehaviour, ITower {
        [SerializeField] TestCreateTower asd;
        [SerializeField] private string type;
        [SerializeField] private float damage;
        [SerializeField] private float attackTime;
        [SerializeField] private float costRequiredToBuy;
        [SerializeField] private List<GameObject> targets = new List<GameObject>();
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float elapsedTime;
        private bool canAttack => !this.IsChargingAttack && target != null;
        bool IsChargingAttack => this.elapsedTime < this.attackTime;
        public void SetUp(TowerData towerData){
            this.name = towerData.name;
            this.type = towerData.towerType;
            this.damage = towerData.damage;
            this.attackTime = towerData.attackSpeed;
            this.costRequiredToBuy = towerData.costRequiredToBuy;
            this.projectilePrefab = towerData.projectilePrefab;
            this.projectileSpeed = towerData.projectileSpeed;
            this.gameObject.AddComponent<SpriteRenderer>().sprite = towerData.mainSprite;
            this.gameObject.AddComponent<SphereCollider>().radius = towerData.attackRange;
            this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        }
        private void Update(){
            UpdateTime();
            if (target == null) UpdateTarget();
            if (canAttack){
                Attack();
            }
        }
        public void UpdateTime(){
            this.elapsedTime += Time.deltaTime;
        }
        public void Attack(){
            var projectile = Instantiate(this.projectilePrefab, this.transform.position, quaternion.identity, this.transform);
            EventBroker.Instance().SendMessage(new EventSpawnBullet(true, target.transform.position, this.projectileSpeed, this.damage));
            this.elapsedTime -= this.attackTime;
        }
        void UpdateTarget(){
            if (targets == null) return;
            this.target = targets.OrderBy(target =>
                (target.transform.position - this.transform.position).sqrMagnitude).FirstOrDefault();
        }
        public void OnTriggerEnter(Collider other){
            if (other.GetComponent<Targetable>()){
                targets.Add(other.GetComponent<Targetable>().thisGuy);
            }
        }
        public void OnTriggerExit(Collider other){
            if (!other.GetComponent<Targetable>()) return;
            if(other.gameObject != null)
                targets.Remove(other.gameObject);
        }
    }
}
