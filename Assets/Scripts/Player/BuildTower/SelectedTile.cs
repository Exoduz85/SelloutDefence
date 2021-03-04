using UnityEngine;
using UnityEngine.Tilemaps;

namespace Player.BuildTower {
    public class SelectedTile : MonoBehaviour {
        [SerializeField]
        GameObject addonSprites;
        [SerializeField]
        Tilemap addons;
        [SerializeField]
        Tilemap tileMap;
        Vector3 mousePosition;
        PlayerGold playerGold;

        void Start() {
            this.playerGold = FindObjectOfType<PlayerGold>();
        }

        void Update() {
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                GetMousePosition();
                ToggleAddonSprites(false);
                if (ValidateTileBase()) return;
                ToggleAddonSprites(true);
            }
        }

        void ToggleAddonSprites(bool shouldShow) {
            this.addonSprites.transform.position = new Vector3(this.mousePosition.x, this.mousePosition.y, 0);
            this.addonSprites.SetActive(shouldShow);
        }

        bool ValidateTileBase() {
            var cell = this.tileMap.WorldToCell(new Vector3(this.mousePosition.x, this.mousePosition.y, this.mousePosition.z));
            var tileBase = this.tileMap.GetTile(cell);
            if (tileBase == null) return true;

            return this.addons.GetTile(cell) != null;
        }

        void GetMousePosition() {
            this.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        public void AssignAddon(Tower.Tower tower) {
            if (this.playerGold.Gold < tower.towerData.towerData.costRequiredToBuy) {
                print("Not enough gold for purchase");
                return;
            }

            Instantiate(tower, new Vector3(this.mousePosition.x, this.mousePosition.y, 0), Quaternion.identity);
            this.playerGold.Gold -= tower.towerData.towerData.costRequiredToBuy;
            print($"Tower purchased for {tower.towerData.towerData.costRequiredToBuy}, gold left: {this.playerGold.Gold}");
            var tileMap = GetComponent<Tilemap>();
            var cell = tileMap.WorldToCell(new Vector3(this.mousePosition.x, this.mousePosition.y, this.mousePosition.z));
            this.addons.SetTile(cell, tower.towerData.towerData.towerAddon);
        }
    }
}