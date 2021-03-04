using Core;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.GameScene {
    public class EnemyHealthHud : MonoBehaviour {
        Image img;
        [SerializeField]
        Health theDamnHealth;


        void Start() {
            this.theDamnHealth = GetComponentInParent<Health>();
            this.img = GetComponent<Image>();
            this.theDamnHealth.updateHealthEvent += UpdateHud;
        }

        void UpdateHud(float i) {
            this.img.fillAmount = i / this.theDamnHealth.maxHealth;
        }
    }
}