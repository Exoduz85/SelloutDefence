using UnityEngine;

namespace HUD {
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
