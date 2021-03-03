using UnityEngine;

namespace Player.Tower {
    [CreateAssetMenu(menuName = "Upgradable Towers List")]
    public class UpgradableTowers : ScriptableObject {
        public UpgradableTowerData[] upgradableTowerDatas;
    }
}