using System;
using Player.Tower;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSelector : MonoBehaviour
{
    public void Initialize(UpgradableTowerData upgradableTowerData) {
        GetComponent<Image>().sprite = upgradableTowerData.sprite;
        
    }
}
