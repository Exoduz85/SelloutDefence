
namespace Enemy{
    public interface IEnemyUnit{
        public void TakeDamage(float damage);
        public bool IsDead{ get; }
    }
}