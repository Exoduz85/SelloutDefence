using System;
using EventBrokerFolder;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.GameScene {
    public class PlayPauseButton : MonoBehaviour {
        public Button playPauseButton;
        public Image play;
        public Image pause;

        public void Start() {
            play.enabled = false;
            pause.enabled = true;
        }

        public void TogglePlayPause() {
            Time.timeScale = Time.timeScale == 1f ? 0f : 1f;
            play.enabled = Time.timeScale == 0;
            pause.enabled = Time.timeScale > 0;
        }

        public void PauseGame() {
            EventBroker.Instance().SendMessage(new EventPlayPauseGame(true));
            TogglePlayPause();
        }
    }
}
