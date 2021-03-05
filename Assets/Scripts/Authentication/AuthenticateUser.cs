using System;
using System.Collections;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;

namespace Authentication {
    public class AuthenticateUser : MonoBehaviour {
        public InputField email;
        public InputField password;

        FirebaseDatabase database;

        string playerKey;
        int gold;

        void Start() {
            this.database = FirebaseDatabase.GetInstance("https://sellout-defense-default-rtdb.firebaseio.com/");
            var auth = FirebaseAuth.DefaultInstance;
            //this.database = FirebaseDatabase.DefaultInstance;
            //this.playerKey = auth.CurrentUser.UserId;

            //print(auth.CurrentUser.UserId);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.T)) {
                this.gold++;
            }

            if (Input.GetKeyDown(KeyCode.R)) {
                Debug.Log(this.gold);
            }

            if (Input.GetKeyDown(KeyCode.S)) {
                SavePlayer();
            }

            if (Input.GetKeyDown(KeyCode.L)) {
                LoadPlayer();
            }
        }

        public void RegisterNewUser() {
            StartCoroutine(HandleRegistration(this.email.text, this.password.text));
        }

        IEnumerator HandleRegistration(string email, string password) {
            var auth = FirebaseAuth.DefaultInstance;

            var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
            yield return new WaitUntil(() => registerTask.IsCompleted);

            if (registerTask.Exception != null) {
                Debug.Log($"failed to register task with {registerTask.Exception}");
            }
            else {
                Debug.Log($"Successfully registered: {registerTask.Result}");
            }
        }

        async void SavePlayer() {
            await this.database.GetReference("Michael").SetValueAsync(this.gold);
            var tsk = await Task.Run(SaveFileExists);
            print(this.database.GetReference("Player"));
            print($"Save file exists: {tsk}");
        }

        async void LoadPlayer() {
            var validateSaveFile = await SaveFileExists();
            if (validateSaveFile) {
                var tsk = await this.database.GetReference("Michael").GetValueAsync();
                this.gold = Convert.ToInt32(tsk.Value);
                print(tsk.Value);
            }
        }

        async Task<bool> SaveFileExists() {
            var dataSnapShot = await this.database.GetReference("Michael").GetValueAsync();
            return dataSnapShot.Exists;
        }
    }
}