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
        public bool active;

        IEnumerator countDown(float countDownStartTime) {
            var spaceTMP = countDownStartTime;
            while (spaceTMP > 0) {
                spaceTMP -= Time.deltaTime;
                timerCountDownText.text = spaceTMP.ToString("0");
            }
            GetComponent<Button>().interactable = true;
            yield return null;
        }

        public void playWaveButton() {
            GetComponent<Button>().interactable = false;
            EventBroker.Instance().SendMessage(new EventStartWave(true));
            StartCoroutine(countDown(10));
        }
    }
}