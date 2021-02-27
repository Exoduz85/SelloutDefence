using UnityEngine;

namespace Player.Tower {
    public class EventSpawnBullet {
        public readonly bool canMove;
        public readonly Transform to;
        public readonly Transform parentTower;
        public readonly float speed;
        public readonly float damage;

        public EventSpawnBullet(Transform parentTower, bool canMove, Transform to, float speed, float damage) {
            this.canMove = canMove;
            this.to = to;
            this.speed = speed;
            this.damage = damage;
            this.parentTower = parentTower;
        }
    }
}