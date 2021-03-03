using System.Collections;
using System.Collections.Generic;
using Enemy;
using EventBrokerFolder;
using UnityEngine;

namespace HUD {
    public class PlayWave : MonoBehaviour
    {
        public void playWaveButton() {
            EventBroker.Instance().SendMessage(new EventStartWave(true));
        }
    }
}