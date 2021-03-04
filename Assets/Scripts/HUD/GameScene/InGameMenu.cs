using UnityEngine;

namespace HUD.GameScene {
    public class InGameMenu : MonoBehaviour {
        
        public void Toggle(GameObject gameObject) {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}