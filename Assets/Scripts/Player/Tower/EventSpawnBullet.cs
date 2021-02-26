using UnityEngine;

namespace Player.Tower {
    public class EventSpawnBullet {
        public readonly bool canMove;
        public readonly Vector3 to;
        public readonly float speed;
        public readonly float damage;

        public EventSpawnBullet(bool canMove, Vector3 to, float speed, float damage) {
            this.canMove = canMove;
            this.to = to;
            this.speed = speed;
            this.damage = damage;
        }
    }
}