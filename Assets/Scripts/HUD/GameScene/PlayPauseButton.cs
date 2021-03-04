

using UnityEngine;
using UnityEngine.UI;

public class PlayPauseButton : MonoBehaviour {
        public Button playPauseButton;
        public GameObject play;
        public GameObject pause;

        public void Start() {
            play = GameObject.FindGameObjectWithTag("play");
            pause = GameObject.FindGameObjectWithTag("pause");
        }

        public void TogglePlayPauseImage() {
            if (Time.timeScale != 0) {
                play.SetActive(true);
            }
            else if (Time.timeScale >= 1) {
                play.SetActive(false);
                pause.SetActive(true);
            }
}

        public void TogglePlayPause() {
            Time.timeScale = Time.timeScale == 1f ? 0f : 1f;
            if (Time.timeScale == 0) {
                play.SetActive(false);
                pause.SetActive(true);
            }
            else if (Time.timeScale >= 1) {
                pause.SetActive(false);
                play.SetActive(true);
            }
        }
    
}
