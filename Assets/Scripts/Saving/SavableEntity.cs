using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Saving {
    [ExecuteAlways]
    public class SavableEntity : MonoBehaviour {
        [SerializeField]
        string uniqueID = "";

#if UNITY_EDITOR
        void Update() {
            if (Application.IsPlaying(this.gameObject)) return;

            if (string.IsNullOrEmpty(this.gameObject.scene.path)) return;
            var serializedObject = new SerializedObject(this);
            var property = serializedObject.FindProperty("uniqueID");

            if (property.stringValue != "") return;

            this.uniqueID = Guid.NewGuid().ToString();
            serializedObject.ApplyModifiedProperties();
        }
#endif

        public string UniqueIdentifier() {
            return this.uniqueID;
        }

        public object CaptureState() {
            var state = new Dictionary<string, object>();
            foreach (var savable in GetComponents<ISavable>()) state[savable.GetType().ToString()] = savable.CaptureState();

            return state;
        }

        public void RestoreState(object state) {
            var stateDictionary = (Dictionary<string, object>) state;

            foreach (var savable in GetComponents<ISavable>()) {
                var typeString = savable.GetType().ToString();
                if (stateDictionary.ContainsKey(typeString)) savable.RestoreState(stateDictionary[typeString]);
            }
        }
    }
}