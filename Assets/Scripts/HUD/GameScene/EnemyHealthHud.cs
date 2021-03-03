using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace HUD.GameScene {
    public class EnemyHealthHud : MonoBehaviour {
        public float health;
        Image img;
        float value;

        void Start() {
            this.img = GetComponent<Image>();
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.D)) {
                DealDamage(5);
            }
        }

        void DealDamage(float i) {
            value = this.img.fillAmount - i / this.health;
            print(this.value);
            StartCoroutine(LerpSomething());
        }

        IEnumerator LerpSomething() {
            while (this.img.fillAmount > this.value) {
                this.img.fillAmount = Mathf.Lerp(this.img.fillAmount, this.value, .1f);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}