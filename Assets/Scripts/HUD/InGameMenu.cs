using Player.Energy;
using UnityEngine;

namespace HUD {
    public class InGameMenu : MonoBehaviour {
        
        public void Toggle(GameObject gameObject) {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}