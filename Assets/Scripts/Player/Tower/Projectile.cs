using Core;
using Unity.Mathematics;
using UnityEngine;

namespace Player.Tower{
    public class Projectile : MonoBehaviour{
        public bool move = false;
        [SerializeField]public Transform to;
        public float speed;
        public float damage;
        private void Update(){
            if (!move) 
                return;
            
            //enemy has already been destroyed by a fellow projectile
            if (to == null){
                Destroy(this.gameObject);
                return;
            }
            
            float angle = Mathf.Atan2(this.transform.position.y - to.position.y, this.transform.position.x - to.position.x) - 90 * Mathf.Rad2Deg;
            this.transform.rotation = quaternion.Euler(0,0, angle);
            this.transform.position = Vector3.MoveTowards(this.transform.position, to.position, speed * Time.deltaTime);
        }
        public void StartMove(Transform targetTransform, float projectileSpeed, float projectileDamage, bool canMove){
            this.to = targetTransform;
            this.speed = projectileSpeed;
            this.damage = projectileDamage;
            this.move = canMove;
        }
        public void OnTriggerEnter(Collider other){
            if (other.CompareTag("Enemy")){
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
        }

        void DealDamage(EventTakeDamage damage) {
            
        }
    }
}
