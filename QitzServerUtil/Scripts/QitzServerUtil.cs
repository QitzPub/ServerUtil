using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Qitz.Server
{
    public class QitzServerUtil
    {

        static readonly string NTP_URL = "https://ntp-a1.nict.go.jp/cgi-bin/json";

        public static IEnumerator GetStringFromUrl(string url, Action<string> callBack)
        {

            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.Send();
            if (request.isNetworkError)
            {
                Debug.LogError(request.error);
                yield break;
            }
            else
            {
                string text = request.downloadHandler.text;
                callBack(text);
            }
        }

        private QitzServerUtil()
        {
        }

        /// <summary>
        /// サーバー時刻を取得します
        /// </summary>
        /// <returns>The NTPS erver time.</returns>
        /// <param name="callback">Callback.</param>
        public static IEnumerator GetNTPServerTime(Action<DateTime> callback)
        {
            var req = UnityWebRequest.Get(NTP_URL);

            yield return req.SendWebRequest();

            if (req.isNetworkError)
            {
                Debug.LogError(req.error);
            }
            else
            {
                var response = JsonUtility.FromJson<NTPServerInfo>(req.downloadHandler.text);
                callback(response.DateTime);
            }
        }

        [Serializable]
        class NTPServerInfo
        {
            public string id;
            public double it;
            public double st;
            public int leap;
            public long next;
            public int step;
            public double TimeStamp
            {
                get
                {
                    return st;
                }
            }
            public DateTime DateTime
            {
                get
                {
                    var startDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    var unixDate = startDate.AddSeconds(st);
                    return unixDate.ToLocalTime();
                }
            }

        }
    }
}