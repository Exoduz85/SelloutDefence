using System;
using System.Collections;
using EventBrokerFolder;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core {
    public class SceneLoader : MonoBehaviour {
        void Start() {
            EventBroker.Instance().SubscribeMessage<EventLoadScene>(LoadScene);
        }

        void OnDestroy() {
            EventBroker.Instance().UnsubscribeMessage<EventLoadScene>(LoadScene);
        }

        void LoadScene(EventLoadScene scene) {
            StartCoroutine(LoadSceneAsync(scene.sceneToLoad));
        }

        IEnumerator LoadSceneAsync(string sceneToLoad) {
            yield return SceneManager.LoadSceneAsync(sceneToLoad);
        }
    }
}