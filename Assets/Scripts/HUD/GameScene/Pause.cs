using System;
using EventBrokerFolder;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.GameScene {
    public class Pause : MonoBehaviour {
        private float timeScaleBeforePause;
        
        public void TogglePlayPause() {
            if (Time.timeScale != 0f) {
                timeScaleBeforePause = Time.timeScale;
                Time.timeScale = 0f;
            } else {
                Time.timeScale = timeScaleBeforePause;
            }
        }

        public void PauseGame() {
            EventBroker.Instance().SendMessage(new EventPlayPauseGame(true, timeScaleBeforePause));
            TogglePlayPause();
        }
    }
}
