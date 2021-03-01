using UnityEngine;

namespace Core {
    public class PersistantObjects : MonoBehaviour {
        static bool hasBeenInstantiated;

        public GameObject persistantObjects;

        void Awake() {
            if (hasBeenInstantiated) return;

            SpawnObjects();
            hasBeenInstantiated = true;
        }

        void SpawnObjects() {
            var persistantObject = Instantiate(this.persistantObjects);
            DontDestroyOnLoad(persistantObject);
        }
    }
}