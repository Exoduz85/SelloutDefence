namespace Player.Energy {
    public class PlayerEnergyChangeEvent {
        public readonly int RemainingEnergy;

        public PlayerEnergyChangeEvent(int remainingEnergy) {
            this.RemainingEnergy = remainingEnergy;
        }
    }
}