using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HUD {
    public class DefeatMenu : MonoBehaviour{
        //when a player dies
        //this menu shows up
        //Continue(costs 1 coin or smth) / Restart / MainMenu
        public string mainText = "Defeat!";
        
        //Drag button from the Editor to this
        public Button restartButton;

        public void ShowDefeatMenu(GameObject gameObject) {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void OnDefeat() {
        }
    }
}