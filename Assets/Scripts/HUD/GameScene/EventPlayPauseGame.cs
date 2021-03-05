namespace HUD.GameScene {
    public class EventPlayPauseGame {
        public bool isGamePaused;
        public float playbackSpeed;

        public EventPlayPauseGame(bool isGamePaused, float playbackSpeed) {
            this.isGamePaused = isGamePaused;
            this.playbackSpeed = playbackSpeed;
        }
    }
}