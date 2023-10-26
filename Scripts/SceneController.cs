using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //画面がクリックされたとき
        if (Input.GetMouseButtonDown(0))
        {
            //Gameシーンを読み込む
            SceneManager.LoadScene("Stage4");
        }
    }
}