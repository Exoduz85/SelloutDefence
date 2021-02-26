using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD {
    public class MainMenuButton : MonoBehaviour {
        
        //Drag button from the Editor to this
        public Button mainMenuButton;

        void OnEnable()
        {
            //Register Button Event
            mainMenuButton.onClick.AddListener(() => buttonCallBack());
        }

        private void buttonCallBack()
        {
            //Get current scene name
            string scene = SceneManager.GetSceneByName("MainMenu").ToString();
            //Load it
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        public object Scenes { get; set; }

        void OnDisable()
        {
            //Un-Register Button Event
            mainMenuButton.onClick.RemoveAllListeners();
        }
    }
}