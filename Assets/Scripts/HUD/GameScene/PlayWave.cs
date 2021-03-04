using System.Collections;
using Enemy;
using EventBrokerFolder;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.GameScene {
    public class PlayWave : MonoBehaviour {
        public Text timerCountDownText;
        public float countDownStart = 10f;
        string buttonStartText;

        public void Start() {
            this.buttonStartText = this.timerCountDownText.text;
        }

        IEnumerator countDown(float countDownStartTime) {
            var spaceTMP = countDownStartTime;
            while (spaceTMP > 0) {
                spaceTMP -= Time.deltaTime;
                this.timerCountDownText.text = spaceTMP.ToString("0");
                yield return null;
            }
            GetComponent<Button>().interactable = true;
            this.timerCountDownText.text = this.buttonStartText;
        }

        public void playWaveButton() {
            GetComponent<Button>().interactable = false;
            EventBroker.Instance().SendMessage(new EventStartWave(true));
            StartCoroutine(countDown(this.countDownStart));
        }
    }
}