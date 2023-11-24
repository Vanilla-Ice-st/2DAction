using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText = null;
    private int oldScore = 0;

    void Start()
    {
        scoreText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            scoreText.text = "SCORE:" + GManager.instance.score;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        //毎フレームでスコアの参照をして重くならないようにスコアの変動があった場合のみ実行
        if (oldScore != GManager.instance.score)
        {
            scoreText.text = "SCORE:" + GManager.instance.score;
            oldScore = GManager.instance.score;
        }
    }

    public static void ScoreReset()
    {
        //スコア初期化
        GManager.instance.score = 0;
    }
}