using System;
using System.Collections;
using Enemy;
using EventBrokerFolder;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.GameScene {
    public class NextWave : MonoBehaviour {
        public Text timerCountDownText;
        public float countDownStart = 10f;
        private string _buttonStartText;

        public void Start() {
            _buttonStartText = timerCountDownText.text;
        }

        private IEnumerator CountDown(float countDownStartTime) {
            var spaceTMP = countDownStartTime;
            while (spaceTMP > 0) {
                spaceTMP -= Time.deltaTime;
                timerCountDownText.text = spaceTMP.ToString("0");
                yield return null;
            }
            GetComponent<Button>().interactable = true;
            timerCountDownText.text = _buttonStartText;
        }

        public void NextWaveButton() {
            GetComponent<Button>().interactable = false;
            EventBroker.Instance().SendMessage(new EventStartWave(true));
            StartCoroutine(CountDown(countDownStart));
        }
    }
}