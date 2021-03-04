using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayPauseButton : MonoBehaviour
{
    public class FastForward : MonoBehaviour {
        public Button playPauseButton;
        public Image play;
        public Image pause;

        public void TogglePlayPause() {
            Time.timeScale = Time.timeScale == 1f ? 0f : 1f;
            if (Time.timeScale >= 0) {
                play.enabled = pause.enabled != true;
            }
        }
    }
}
