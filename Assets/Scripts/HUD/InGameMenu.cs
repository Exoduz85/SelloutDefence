using Player.Energy;
using UnityEngine;

namespace HUD {
    public class InGameMenu : MonoBehaviour {

        public int energy;
        
        public void Toggle(GameObject gameObject) {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        private void ContinueButton() {
            //return player to full health
            //continue only if energy is not 0
            
            if (energy > 1) {
                
            }
        }

        public void RestartButton() {
            
        }

        public void MainMenuButton() {
            
        }

        public void CancelButton() {
            
        }
        
    }
}