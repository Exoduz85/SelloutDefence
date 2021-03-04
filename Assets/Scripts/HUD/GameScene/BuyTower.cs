using Player.Tower;
using UnityEngine;

namespace HUD.GameScene{
    public class BuyTower : MonoBehaviour
    {
        // this is just a test script..
        public TowerData tower;
        public void CreateOneTower(){
            var instance = new GameObject();
            instance.transform.position = Vector3.zero;
            instance.AddComponent<SpriteRenderer>();
            instance.name = this.tower.name;
            instance.AddComponent<Tower>();
            instance.GetComponent<Tower>().SetUp(this.tower);
        }

    }
}
