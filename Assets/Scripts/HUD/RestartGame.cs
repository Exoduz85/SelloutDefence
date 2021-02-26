using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD {
    public class RestartGame : MonoBehaviour {
        
        //Drag button from the Editor to this
        public Button restartButton;

        void OnEnable()
        {
            //Register Button Event
            restartButton.onClick.AddListener(() => buttonCallBack());
        }

        private void buttonCallBack()
        {
            Debug.Log("Clicked: " + restartButton.name);
            //Get current scene name
            string scene = SceneManager.GetActiveScene().name;
            //Load it
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        void OnDisable()
        {
            //Un-Register Button Event
            restartButton.onClick.RemoveAllListeners();
        }
    }
}