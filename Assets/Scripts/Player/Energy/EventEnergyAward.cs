namespace Player.Energy {
    public class EventEnergyAward {
        public readonly int EnergyToUpdate;
        public bool HasEnergy;
        public EventEnergyAward(int energyToUpdate) {
            this.EnergyToUpdate = energyToUpdate;
        }
    }
}