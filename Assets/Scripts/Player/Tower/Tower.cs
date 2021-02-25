using Enemy;
using UnityEngine;

namespace Player.Tower{
    public class Tower : MonoBehaviour, ITower{
        private TowerData towerData;
        [SerializeField] private string type;
        [SerializeField] private float damage;
        [SerializeField] private float attackTime;
        [SerializeField] private float attackRange;
        [SerializeField] private float costRequiredToBuy;
        private GameObject target;
        private float elapsedTime;
        private bool canAttack => !this.IsChargingAttack && target != null;
        bool IsChargingAttack => this.elapsedTime < this.attackTime;
        public void SetUp(TowerData towerData){
            this.towerData = towerData;
            this.name = towerData.name;
            this.type = towerData.towerType;
            this.damage = towerData.damage;
            this.attackRange = towerData.attackRange;
            this.attackTime = towerData.attackTime;
            this.costRequiredToBuy = towerData.costRequiredToBuy;
        }
        public void UpdateTime(){
            this.elapsedTime += Time.deltaTime;
        }
        public void Attack(){
            if (canAttack){
                this.elapsedTime -= this.attackTime;
            }
        }
        private void OnTriggerEnter(Collider other){
            if (other.GetComponent<EnemyUnit>()){
                target = other.gameObject;
            }
        }
    }
}
