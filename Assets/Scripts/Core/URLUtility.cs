using System;
using System.Globalization;
using System.Net;
using UnityEngine;

namespace Core {
    public class URLUtility : MonoBehaviour {
        public static DateTime LastLogin { get; private set; }

        public static DateTime Now() {
            return GetTime();
        }

        static DateTime GetTime() {
            var myHttpWebRequest = (HttpWebRequest) WebRequest.Create("http://www.microsoft.com");
            var response = myHttpWebRequest.GetResponse();
            var todayDate = response.Headers["date"];
            return DateTime.ParseExact(todayDate,
                "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                CultureInfo.InvariantCulture.DateTimeFormat,
                DateTimeStyles.AssumeUniversal);
        }
    }
}