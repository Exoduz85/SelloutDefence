using UnityEngine;
using UnityEngine.UI;

namespace HUD {
    public class FastForward : MonoBehaviour {
        public Button fastForwardButton;
        public Text fastForwardText;

        public void Toggle() {
            Time.timeScale = Time.timeScale == 1f ? 2f : 1f;
            fastForwardText.text = Time.timeScale.ToString(Time.timeScale + "x");
        }
    }
}
