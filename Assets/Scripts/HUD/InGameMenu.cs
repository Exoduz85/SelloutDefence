using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD {
    public class InGameMenu : MonoBehaviour {
        public Button ContinueButton;
        public Button RestartButton;
        public Button MainMenuButton;
        public Button CancelButton;

        public void Toggle(GameObject gameObject) {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    
    
        public void RestartMenu() {
        
            if (RestartButton) {
                SceneManager.LoadScene("Scenes/SampleScene");
            }
        }

        public void OnClick() {
        
        }
    }
}