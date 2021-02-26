using UnityEngine;

namespace Enemy{
    public class Targetable : MonoBehaviour{
        public GameObject thisGuy;
        private void OnEnable(){
            this.thisGuy = this.gameObject;
        }
    }
}