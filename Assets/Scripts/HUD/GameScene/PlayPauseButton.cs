using System;
using EventBrokerFolder;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.GameScene {
    public class PlayPauseButton : MonoBehaviour {
        public Button playPauseButton;
        public Image play;
        public Image pause;
        private float timeScaleBeforePause;

        public void Start() {
            play.enabled = false;
            pause.enabled = true;
        }

        public void TogglePlayPause() {
            if (Time.timeScale != 0f) {
                timeScaleBeforePause = Time.timeScale;
                Time.timeScale = 0f;
            } else {
                Time.timeScale = timeScaleBeforePause;
            }
            play.enabled = Time.timeScale == 0;
            pause.enabled = Time.timeScale > 0;
        }

        public void PauseGame() {
            EventBroker.Instance().SendMessage(new EventPlayPauseGame(true, timeScaleBeforePause));
            TogglePlayPause();
        }
    }
}
