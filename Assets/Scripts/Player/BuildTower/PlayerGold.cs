using System;
using UnityEngine;

namespace Player.BuildTower {
    public class PlayerGold : MonoBehaviour {
        public int Gold { get; set; }

        void Start() {
            this.Gold = 30;
        }
    }
}