using System;
using UnityEngine;

namespace Enemy{
    public class Target : MonoBehaviour{
        public GameObject value;
        private void Start(){
            value = this.gameObject;
        }
    }
}
