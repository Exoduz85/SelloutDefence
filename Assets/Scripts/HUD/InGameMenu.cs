using UnityEngine;

namespace HUD {
    public class InGameMenu : MonoBehaviour {
        
        public void Toggle(GameObject gameObject) {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void ContinueButton() {
            
        }

        public void RestartButton() {
            
        }

        public void MainMenuButton() {
            
        }

        public void CancelButton() {
            
        }
        
    }
}