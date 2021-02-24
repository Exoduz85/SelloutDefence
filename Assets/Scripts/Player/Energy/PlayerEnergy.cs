using System;
using System.Collections;
using Core;
using EventBrokerFolder;
using UnityEngine;

namespace Player.Energy {
    //TODO should persist through scenes?
    public class PlayerEnergy : MonoBehaviour {
        int RemainingEnergy { get; set; }

        void Start() {
            EventBroker.Instance().SubscribeMessage<UpdatePlayerEnergyEvent>(UpdateEnergy);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.T)) {
                StartCoroutine(GetTime());
            }
        }

        IEnumerator GetTime() {
            yield return LoginData.GetTime();
            print($"Last Login: {LoginData.LastLogin}   Now: {LoginData.Now}");
            var lst = LoginData.LastLogin.AddDays(2);
            var now = LoginData.Now;
            var diff = now - lst;

            if (Mathf.Abs(diff.Days) > 0) {
                print("inside if");
                var newNow = now.AddDays(-Mathf.Abs(diff.Days));
                diff = newNow.TimeOfDay - lst.TimeOfDay;
            }

            print(Mathf.Abs(diff.Days));
            print(diff.Seconds);
        }

        void UpdateEnergy(UpdatePlayerEnergyEvent energy) {
            this.RemainingEnergy += energy.EnergyToUpdate;
            Debug.Log($"Remaining energy: {this.RemainingEnergy}");
        }
    }
}