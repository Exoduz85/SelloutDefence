using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour {
    public Button fastForwardButton;
    public Text fastForwardText;

    public void Toggle() {
        if (Time.timeScale == 1f) {
            Time.timeScale = 2f;
            fastForwardText.text = Time.timeScale.ToString(Time.timeScale + "x");
        } else {
            Time.timeScale = 1f;
            fastForwardText.text = Time.timeScale.ToString(Time.timeScale + "x");
        }
    }
}
