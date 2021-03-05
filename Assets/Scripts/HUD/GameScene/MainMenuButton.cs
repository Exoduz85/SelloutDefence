using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD.GameScene {
    public class MainMenuButton : MonoBehaviour {
        
        public void ButtonCallBack()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}