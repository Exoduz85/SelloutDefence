using EventBrokerFolder;
using UnityEngine;

namespace Player.Energy {
    [CreateAssetMenu]
    public class Energy : ScriptableObject {
        public int maxEnergy;
        
        [SerializeField]
        int remainingEnergy;

        public int RemainingEnergy {
            get => this.remainingEnergy;
            set {
                this.remainingEnergy = Mathf.Clamp(value, 0, this.maxEnergy);
                EventBroker.Instance().SendMessage(new EventEnergyChange(this.RemainingEnergy));
            }
        }
    }
}