using System;
using UnityEngine;

namespace Player.Tower{
    public class TestCreateTower : MonoBehaviour{
        public TowerData TowerData;
        private void Start(){
            var tower = new GameObject();
            tower.transform.position = Vector3.zero;
            tower.AddComponent<Tower>().SetUp(this.TowerData);
        }
    }
}