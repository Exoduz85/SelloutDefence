using System;
using Firebase.Auth;
using UnityEngine;

namespace Core {
    public class Health : MonoBehaviour {
        public float health;
        bool IsDead => this.health <= 0f;

        public Action<float> updateHealthEvent;

        public float maxHealth;

        void Start() {
            this.maxHealth = this.health;
        }

        public void TakeDamage(float takeDamage) {
            this.health -= takeDamage;

            this.updateHealthEvent?.Invoke(this.health);
            if (this.IsDead) {
                Destroy(this.gameObject);
            } 
        }
    }
}