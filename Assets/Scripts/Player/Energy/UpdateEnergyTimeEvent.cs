namespace Player.Energy {
    public class UpdateEnergyTimeEvent {
        public readonly float Timer;

        public UpdateEnergyTimeEvent(float timer) {
            this.Timer = timer;
        }
    }
}