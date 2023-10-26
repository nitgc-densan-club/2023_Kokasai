using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitController : MonoBehaviour
{
    //ユニティちゃんを格納する変数
    public GameObject player;
    //テキストを格納する変数
    public GameObject text;

    //RestartManager型
    private RestartManager restart;

    public GameObject StageAudio;
    public GameObject GameOverAudio;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンス生成
        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {
        if (restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトがユニティちゃんのとき
        if (other.gameObject.name == player.name)
        {
            restart.PrintGameOver();
            StageAudio.SetActive(false);
            GameOverAudio.SetActive(true);
        }
    }
}