using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using EventBrokerFolder;
using UnityEngine;
using UnityEngine.UI;

namespace HUD {
    public class PlayWave : MonoBehaviour {
        public Text timerCountDownText;
        public float countDownStart = 10f;
        string buttonStartText;

        public void Start() {
            buttonStartText = timerCountDownText.text;
        }

        IEnumerator countDown(float countDownStartTime) {
            var spaceTMP = countDownStartTime;
            while (spaceTMP > 0) {
                spaceTMP -= Time.deltaTime;
                timerCountDownText.text = spaceTMP.ToString("0");
                yield return null;
            }
            GetComponent<Button>().interactable = true;
            timerCountDownText.text = buttonStartText;
        }

        public void playWaveButton() {
            GetComponent<Button>().interactable = false;
            EventBroker.Instance().SendMessage(new EventStartWave(true));
            StartCoroutine(countDown(countDownStart));
        }
    }
}