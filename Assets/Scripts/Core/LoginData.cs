using System;
using System.Collections;
using System.Globalization;
using System.Net;
using Saving;
using UnityEngine;
using UnityEngine.Networking;

namespace Core {
    public class LoginData : MonoBehaviour, ISavable {
        /// <summary>
        /// Set when exiting the scene
        /// </summary>
        public static DateTime LastLogin { get; private set; }


        /// <summary>
        /// Has to be called in a Coroutine together with GetTime
        /// </summary>
        public static DateTime Now { get; set; }

        void Start() {
            StartCoroutine(GetTime());
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.S))
                StartCoroutine(SaveGame());

            if (Input.GetKeyDown(KeyCode.L))
                StartCoroutine(FindObjectOfType<SaveSystem>().Load());
            
            if (Input.GetKeyDown(KeyCode.G))
                StartCoroutine(GetTime());
        }

        IEnumerator SaveGame() {
            var saveSystem = FindObjectOfType<SaveSystem>();
            yield return GetTime();
            yield return saveSystem.Save();
        }

        public static IEnumerator GetTime() {
            var webRequest = new UnityWebRequest("http://www.microsoft.com");
            var sendRequest = webRequest.SendWebRequest();
            yield return sendRequest;
            var todayDate = sendRequest.webRequest.GetResponseHeaders()["date"];
            Now = DateTime.ParseExact(todayDate,
                "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                CultureInfo.InvariantCulture.DateTimeFormat,
                DateTimeStyles.AssumeUniversal);
        }

        public object CaptureState() {
            LastLogin = Now;
            return LastLogin;
        }


        public void RestoreState(object state) {
            LastLogin = (DateTime) state;
        }
    }
}