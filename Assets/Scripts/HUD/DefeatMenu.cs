using System;
using UnityEngine;

namespace HUD {
    public class DefeatMenu {
        //when a player dies
        //this menu shows up
        //Continue(costs 1 coin or smth) / Restart / MainMenu

        public int towerHealth;
        
        public void ShowDefeatMenu(GameObject gameObject) {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        public void OnDefeat() {
        }
    }
}