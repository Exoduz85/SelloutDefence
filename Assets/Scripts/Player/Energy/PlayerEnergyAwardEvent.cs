namespace Player.Energy {
    public class PlayerEnergyAwardEvent {
        public readonly int EnergyToUpdate;

        public PlayerEnergyAwardEvent(int energyToUpdate) {
            this.EnergyToUpdate = energyToUpdate;
        }
    }
}