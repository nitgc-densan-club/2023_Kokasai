using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private bool isGoal = false;
    //目的地となるオブジェクトのトランスフォーム格納用
    int flame = 0;
    public Transform target;
    //エージェントとなるオブジェクトのNavMeshAgent格納用
    public NavMeshAgent agent;

    // Use this for initialization
    void Update()
    {
        //目的地となる座標を設定する
        if (flame % 120 == 0)
        {
            agent.destination = target.position;
        }
        flame++;
    }
}