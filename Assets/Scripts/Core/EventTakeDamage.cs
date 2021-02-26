namespace Core {
    public class EventTakeDamage {
        public readonly float damageToDeal;
        public readonly bool isDead;

        public EventTakeDamage(float damageToDeal, bool isDead) {
            this.damageToDeal = damageToDeal;
            this.isDead = isDead;
        }
    }
}