using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD.GameScene {
    public class RestartGame : MonoBehaviour {
        
        //Drag button from the Editor to this
        public Button restartButton;

        void OnEnable()
        {
            //Register Button Event
            this.restartButton.onClick.AddListener(() => buttonCallBack());
        }

        private void buttonCallBack()
        {
            Debug.Log("Clicked: " + this.restartButton.name);
            //Get current scene name
            string scene = SceneManager.GetActiveScene().name;
            //Load it
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        void OnDisable()
        {
            //Un-Register Button Event
            this.restartButton.onClick.RemoveAllListeners();
        }
    }
}