using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityChan;

public class DeadWallController : MonoBehaviour
{
    //オブジェクトの速度
    public float speed = 0.05f;
    //オブジェクトの横移動の最大距離
    public float max_x = 10.0f;

    //ユニティちゃんを格納する変数
    public GameObject player;
    //テキストを格納する変数
    public GameObject text;

    public GameObject StageAudio;
    public GameObject GameOverAudio;

    //ゲームオーバー判定
    private bool isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        //フレーム毎speedの値分だけx軸方向に移動する
        this.gameObject.transform.Translate(speed, 0, 0);

        //Transformのxの値が一定値を超えたときに向きを反対にする
        if (this.gameObject.transform.position.x > max_x || this.gameObject.transform.position.x < (-max_x))
        {
            speed *= -1;
        }

        //ゲームオーバー状態で画面がクリックされたとき
        if (isGameOver && Input.GetMouseButton(0))
        {
            Restart();
        }
    }

    //ユニティちゃんとの当たり判定
    private void OnCollisionEnter(Collision other)
    {
        //接触したオブジェクトがユニティちゃんのとき
        if (other.gameObject.name == player.name)
        {
            //ゲームオーバーを表示する
            text.GetComponent<Text>().text = "GameOver...";
            text.SetActive(true);

            //ユニティちゃんを動けなくする
            player.GetComponent<UnityChanControlScriptWithRgidBody>().enabled = false;
            //アニメーションをオフにする
            player.GetComponent<Animator>().enabled = false;

            StageAudio.SetActive(false);
            GameOverAudio.SetActive(true);

            //ゲームオーバー
            isGameOver = true;
        }
    }

    //シーンを再読み込みする
    private void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
    }
}