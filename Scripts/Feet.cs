using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Feet : MonoBehaviour
{
    public GameObject LegAudio;
    private int h = 0;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        //LegAudio.SetActive(true);
        count = 0;
        StartCoroutine("se");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            /*if (count % 20 == 0)
            {
                //LegAudio.SetActive(true);
            }
            h = 1;*/
            //StartCoroutine("se");
            h = 1;
        }
        else {
            //LegAudio.SetActive(false);
            h = 0;
        }
        if(count % 60 == 0 && h == 1)
        {
            //LegAudio.SetActive(true);
            //LegAudio.SetActive(false);
        }
        if (count % 60 == 0)
        {
            //LegAudio.SetActive(true);
        }
        count++;
    }
    IEnumerator se()
    {
        //ここに処理を書く
        while (true)
        {
            if(h==1)
            {
                LegAudio.SetActive(true);
                yield return new WaitForSeconds(1);
                LegAudio.SetActive(false);
                yield return new WaitForSeconds(1);
            }
            yield break;
        }

        //yield break;
    }
}
