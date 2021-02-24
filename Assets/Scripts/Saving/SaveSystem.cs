using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Saving {
    public class SaveSystem : MonoBehaviour {
        const string SaveFileName = "/SelloutDefence.sav";

        public void Save() {
            var path = GetFilePath(SaveFileName);
            print($"Saving {path}");
            var state = LoadFile(path);
            CaptureState(state);
            SaveFile(SaveFileName, state);
        }

        public void Load() {
            var path = GetFilePath(SaveFileName);
            print($"Loading {path}");
            RestoreState(LoadFile(path));
        }

        void SaveFile(string saveFile, object state) {
            var path = GetFilePath(saveFile);
            using (var stream = File.Open(path, FileMode.Create)) {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        Dictionary<string, object> LoadFile(string saveFile) {
            if (!File.Exists(saveFile)) {
                return new Dictionary<string, object>();
            }

            using (var stream = File.Open(saveFile, FileMode.Open)) {
                var formatter = new BinaryFormatter();
                return (Dictionary<string, object>) formatter.Deserialize(stream);
            }
        }

        void CaptureState(Dictionary<string, object> state) {
            foreach (var entity in FindObjectsOfType<SavableEntity>())
                state[entity.UniqueIdentifier()] = entity.CaptureState();
        }

        void RestoreState(Dictionary<string, object> state) {
            foreach (var entity in FindObjectsOfType<SavableEntity>()) {
                var id = entity.UniqueIdentifier();
                if (state.ContainsKey(id))
                    entity.RestoreState(state[id]);
            }
        }

        string GetFilePath(string fileName)
            => Application.persistentDataPath + fileName;
    }
}