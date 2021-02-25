using System;
using UnityEngine;

namespace Enemy{
    public class UnitSpawner : MonoBehaviour{
        public GameObject unitPrefab;

        public void SpawnUnit(){
            var instance = Instantiate(this.unitPrefab, this.transform);
            instance.GetComponent<EnemyUnit>().SetUp();
        }

        private void Update(){
            if(Input.GetMouseButtonDown(0)) SpawnUnit();
        }
    }
}
