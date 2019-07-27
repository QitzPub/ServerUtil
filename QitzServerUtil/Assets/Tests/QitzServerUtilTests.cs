using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Qitz.Server;

namespace Tests
{
    public class QitzServerUtilTests
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator QitzServerUtilTestsWithEnumeratorPasses()
        {
            yield return QitzServerUtil.GetNTPServerTime((date)=> {
                Debug.Log("Time="+ date.ToString());
            });

            yield return QitzServerUtil.GetStringFromUrl("https://ntp-a1.nict.go.jp/cgi-bin/json", (getedString) =>
            {
                Debug.Log(getedString);
            });
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
