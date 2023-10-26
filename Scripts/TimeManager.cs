using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //時間表示用テキスト
    public Text timeText;
    //制限時間
    public float limit = 30.0f;
    //ゲームオーバー表示用テキスト
    public GameObject text;
    //ユニティちゃん格納用
    public GameObject player;

    public GameObject StageAudio;
    public GameObject GameOverAudio;

    //RestartManager型
    private RestartManager restart;


    // Start is called before the first frame update
    void Start()
    {
        //インスタンス生成
        restart = new RestartManager(player, text);
        //初期時間を設定
        timeText.text = "残り時間:" + limit + "秒";
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバーしていて画面がクリックされたとき
        if (restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }

        //時間制限がきたとき
        if (limit < 0)
        {
            //RestartManagerに処理を任せる
            restart.PrintGameOver();
            StageAudio.SetActive(false);
            GameOverAudio.SetActive(true);

            //ここでUpdateメソッドを終わらせる
            return;
        }

        //時間をカウントダウンする
        limit -= Time.deltaTime;
        timeText.text = "残り時間:" + limit.ToString("f1") + "秒";
    }
}