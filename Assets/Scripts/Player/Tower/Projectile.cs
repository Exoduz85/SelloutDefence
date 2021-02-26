using System;
using Core;
using Enemy;
using EventBrokerFolder;
using Unity.Mathematics;
using UnityEngine;

namespace Player.Tower{
    public class Projectile : MonoBehaviour{
        public bool move = false;
        private Vector3 to;
        private float speed;
        float damage;
        void Start() {
            EventBroker.Instance().SubscribeMessage<EventSpawnBullet>(StartMove);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventSpawnBullet>(StartMove);
        }

        private void Update(){
            if (!move) return;
            float angle = Mathf.Atan2(this.transform.position.y - to.y, this.transform.position.x - to.x) - 90 * Mathf.Rad2Deg;
            this.transform.rotation = quaternion.Euler(0,0, angle);
            this.transform.position = Vector3.MoveTowards(this.transform.position, to, speed * Time.deltaTime);
        }
        void StartMove(EventSpawnBullet spawnBullet){
            this.to = spawnBullet.to;
            this.speed = spawnBullet.speed;
            this.damage = spawnBullet.damage;
            this.move = spawnBullet.canMove;
        }
        public void OnTriggerEnter(Collider other){
            if (other.GetComponent<Targetable>()){
                
                Destroy(this.gameObject);
            }
        }

        void DealDamage(EventTakeDamage damage) {
            
        }
    }
}
