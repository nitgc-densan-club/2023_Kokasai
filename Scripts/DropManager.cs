using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    //ユニティちゃんを格納する変数
    public GameObject player;
    //テキストを格納する変数
    public GameObject text;

    public GameObject timer;

    public GameObject StageAudio;
    public GameObject GameOverAudio;

    //RestartManager型
    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        //インスタンス生成
        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -10)
        {
            restart.PrintGameOver();
            timer.SetActive(false);
            StageAudio.SetActive(false);
            GameOverAudio.SetActive(true);
        }

        if (restart.IsGameOver() && Input.GetMouseButton(0))
        {
            restart.Restart();
        }
    }
}