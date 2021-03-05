using System;
using UnityEditor;
using UnityEngine;

namespace HUD.GameScene {
    public class MenuManager : MonoBehaviour {
        [SerializeField] GameObject NextWaveButton;
        [SerializeField] GameObject FastForwardButton;

        public void ToggleButtons() {
            FastForwardButton.gameObject.SetActive(!FastForwardButton.gameObject.activeSelf);
            NextWaveButton.gameObject.SetActive(!NextWaveButton.gameObject.activeSelf);
        }
    }
}