using System;
using UnityEngine;

namespace Core{
    public class Health : MonoBehaviour{
        public float health;
        public bool IsDead => this.health <= 0f;
        public void TakeDamage(float damage){
            this.health -= damage;
            if (this.IsDead) {
                Destroy(this.gameObject);
            }
        }
    }
}
