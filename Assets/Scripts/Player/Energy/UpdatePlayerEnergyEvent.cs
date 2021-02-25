namespace Player.Energy {
    public class UpdatePlayerEnergyEvent {
        public readonly int EnergyToUpdate;

        public UpdatePlayerEnergyEvent(int energyToUpdate) {
            this.EnergyToUpdate = energyToUpdate;
        }
    }
}