using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour {
    public Button fastForwardButton;
    public Text fastForwardText;

    public void ToggleSpeed() {
        Time.timeScale = Time.timeScale == 1f ? 2f : 1f;
        fastForwardText.text = Time.timeScale.ToString(Time.timeScale + "x");
    }
}
