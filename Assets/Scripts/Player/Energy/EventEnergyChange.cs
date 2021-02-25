namespace Player.Energy {
    public class EventEnergyChange {
        public readonly int RemainingEnergy;

        public EventEnergyChange(int remainingEnergy) {
            this.RemainingEnergy = remainingEnergy;
        }
    }
}