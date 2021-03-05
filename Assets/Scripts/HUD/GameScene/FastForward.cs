using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForward : MonoBehaviour {
    public Button fastForwardButton;
    public Image play;
    public Image fastforward;
    
    public void Start() {
        play.enabled = false;
        fastforward.enabled = true;
    }
    
    public void ToggleSpeed() {
        Time.timeScale = Time.timeScale == 1f ? 2f : 1f;
        play.enabled = Time.timeScale > 1f;
        fastforward.enabled = Time.timeScale == 1f;
    }
}