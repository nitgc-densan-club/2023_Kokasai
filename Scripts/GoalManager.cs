using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class GoalManager : MonoBehaviour
{
    //ユニティちゃんを格納するための変数
    public GameObject player;
    //テキストを格納するための変数
    public GameObject text;

    public GameObject enemy;

    public GameObject time;

    public GameObject Audio;

    public GameObject GoalAudio;

    public GameObject DeadWall;

    public string stage;

    //Goalしたかどうか判定する
    private bool isGoal = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Goalした後で画面をクリックされたとき
        if (isGoal && Input.GetMouseButton(0))
        {
            Restart();
        }
        if (isGoal)
        {
            //ユニティちゃんを動けなくする
            player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
            enemy.SetActive(false);
            time.SetActive(false);
            Audio.SetActive(false);
            DeadWall.SetActive(false);
            GoalAudio.SetActive(true);
        }
    }

    //当たり判定関数
    private void OnTriggerEnter(Collider other)
    {
        //当たってきたオブジェクトの名前がユニティちゃんの名前と同じとき
        if (other.name == player.name)
        {
            //テキストの内容を変更する
            text.GetComponent<Text>().text = "Goal!!!\n画面クリックで"+ stage + "へ";
            //テキストをオンにして非表示→表示にする
            text.SetActive(true);

            //Goal判定をTrueにする
            isGoal = true;
            //Destroy(other.Enemy);
        }
    }

    //シーンを再読み込みする
    private void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(stage);
    }
}