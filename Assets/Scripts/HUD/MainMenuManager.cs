using UnityEngine;

namespace HUD {
    public class MainMenuManager : MonoBehaviour {
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject upgradeSelectionMenu;

        bool ShouldShowMainMenu => !this.upgradeSelectionMenu.activeSelf && !this.mainMenu.activeSelf;

        void Start() {
            this.mainMenu.SetActive(false);
            this.upgradeSelectionMenu.SetActive(false);
        }

        void Update() {
            if(this.upgradeSelectionMenu.activeSelf)
                this.mainMenu.SetActive(false);
            
            if (this.ShouldShowMainMenu)
                this.mainMenu.SetActive(true);
        }

        public void ShowUpgradesMenu() {
            this.upgradeSelectionMenu.SetActive(true);
        }
    }
}
