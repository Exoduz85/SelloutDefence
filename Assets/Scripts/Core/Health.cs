using System;
using EventBrokerFolder;
using UnityEngine;

namespace Core{
    public class Health : MonoBehaviour{
        public float health;
        public bool IsDead => this.health <= 0f;

        void Start() {
            //throw new NotImplementedException();
        }

        public void TakeDamage(EventTakeDamage takeDamage){
            this.health -= takeDamage.damageToDeal;
            
            if (takeDamage.isDead) {
                Destroy(this.gameObject);
            }
        }
    }
}
