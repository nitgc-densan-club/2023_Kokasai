using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController1 : MonoBehaviour
{
    //オブジェクトの速度
    public float speed = 0.05f;
    //オブジェクトの横移動の最大距離
    public float max_y = 10.0f;

    // Update is called once per frame
    void Update()
    {
        //フレーム毎speedの値分だけx軸方向に移動する
        this.gameObject.transform.Translate(0, speed, 0);

        //Transformのxの値が一定値を超えたときに向きを反対にする
        if (this.gameObject.transform.position.y > max_y || this.gameObject.transform.position.y < (-max_y))
        {
            speed *= -1;
        }
    }
}