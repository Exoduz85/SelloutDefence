﻿using System;
using Player.Tower;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Player.BuildTower {
    public class SelectedTile : MonoBehaviour {
        public GameObject addonSprites;
        public Tilemap addons;
        Vector3 position;
        PlayerGold playerGold;

        void Start() {
            this.playerGold = FindObjectOfType<PlayerGold>();
        }

        void Update() {
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                this.addonSprites.SetActive(false);
                this.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var tileMap = GetComponent<Tilemap>();
                var cell = tileMap.WorldToCell(new Vector3(this.position.x, this.position.y, this.position.z));
                var tmp = tileMap.GetTile(cell);
                if (tmp == null) return;

                this.addonSprites.transform.position = new Vector3(this.position.x, this.position.y, 0);
                this.addonSprites.SetActive(true);
            }
        }

        public void AssignAddon(TowerData towerData) {
            if (this.playerGold.Gold < towerData.costRequiredToBuy) {
                print("Not enough gold for purchase");
            }

            //TODO instantiate the tower prefab
            this.playerGold.Gold -= towerData.costRequiredToBuy;
            print($"Tower purchased for {towerData.costRequiredToBuy}, gold left: {this.playerGold.Gold}");
            var tileMap = GetComponent<Tilemap>();
            var cell = tileMap.WorldToCell(new Vector3(this.position.x, this.position.y, this.position.z));
            this.addons.SetTile(cell, towerData.towerAddon);
        }
    }
}