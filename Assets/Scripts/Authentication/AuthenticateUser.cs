using System;
using System.Collections;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;

namespace Authentication {
    public class AuthenticateUser : MonoBehaviour {
        public InputField email;
        public InputField password;

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
    }
}
