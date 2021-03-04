using UnityEngine;

namespace HUD.MainMenu {
    public class CloseMenu : MonoBehaviour {
        [SerializeField] GameObject windowToClose;

        [SerializeField]
        bool destroyWindow;

        public void CloseWindow() {
            if(this.destroyWindow)
                Destroy(this.windowToClose);
            else
                this.windowToClose.SetActive(false);
        }
    }
}
