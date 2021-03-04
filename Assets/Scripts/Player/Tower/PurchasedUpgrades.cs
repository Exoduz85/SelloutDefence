using System;
using System.Collections.Generic;
using Saving;
using UnityEngine;

namespace Player.Tower {
    public class PurchasedUpgrades : MonoBehaviour, ISavable{
        
        [SerializeField] UpgradableTowers towerList;
        Dictionary<string, int[]> upgradesDic = new Dictionary<string, int[]>();
        
        public object CaptureState() {
            // this.upgradesDic = new Dictionary<string, int[]>();
            foreach (var tower in this.towerList.upgradableTowerDatas) {
                this.upgradesDic[tower.name] = new[] {tower.DmgUpgradeCount, tower.RangeUpgradeCount, tower.SpeedUpgradeCount};
            }
            return this.upgradesDic;
        }

        public void RestoreState(object state) {
            this.upgradesDic = (Dictionary<string, int[]>) state;
            
            foreach (var tower in this.towerList.upgradableTowerDatas) {
                tower.RestoreStats(this.upgradesDic[tower.name]);
            }
        }
    }
}