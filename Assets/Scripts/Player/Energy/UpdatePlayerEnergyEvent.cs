namespace Player.Energy {
    public abstract class UpdatePlayerEnergyEvent {
        public readonly int EnergyToUpdate;

        protected UpdatePlayerEnergyEvent(int energyToUpdate) {
            this.EnergyToUpdate = energyToUpdate;
        }
    }
}