# QitzのServerUtil！！

# 使い方
Unity向けのパッケージをダウンロードしてプロジェクトにインスコする!
https://github.com/QitzPub/ServerUtil/raw/master/QitzServerUtil1.0.0.unitypackage

ネームスペースを読み込む
```C#
using Qitz.Server;
```

以下のような形で読み込む！
```C#
        public IEnumerator QitzServerUtilTestsWithEnumeratorPasses()
        {
            //サーバー時間を取得！
            yield return QitzServerUtil.GetNTPServerTime((date)=> {
                Debug.Log("Time="+ date.ToString());
            });
            //サーバーから文字データを取得！
            yield return QitzServerUtil.GetStringFromUrl("https://ntp-a1.nict.go.jp/cgi-bin/json", (getedString) =>
            {
                Debug.Log(getedString);
            });
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
```
