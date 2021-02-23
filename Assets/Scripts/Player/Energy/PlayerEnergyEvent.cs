namespace Player.Energy {
    public class PlayerEnergyEvent {
        public readonly IPlayerEnergy Energy;

        public PlayerEnergyEvent(IPlayerEnergy energy) {
            this.Energy = energy;
        }
    }
}