namespace Player.Energy {
    public class UpdatePlayerEnergyEvent {
        public readonly int EnergyToUpdate;
        public readonly int PlayerEnergy;

        public UpdatePlayerEnergyEvent(int energyToUpdate, int playerEnergy) {
            this.EnergyToUpdate = energyToUpdate;
            this.PlayerEnergy = playerEnergy;
        }

        public UpdatePlayerEnergyEvent(int playerEnergy) {
            this.PlayerEnergy = playerEnergy;
        }
    }
}