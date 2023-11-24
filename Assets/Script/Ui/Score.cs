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
        //���t���[���ŃX�R�A�̎Q�Ƃ����ďd���Ȃ�Ȃ��悤�ɃX�R�A�̕ϓ����������ꍇ�̂ݎ��s
        if (oldScore != GManager.instance.score)
        {
            scoreText.text = "SCORE:" + GManager.instance.score;
            oldScore = GManager.instance.score;
        }
    }

    public static void ScoreReset()
    {
        //�X�R�A������
        GManager.instance.score = 0;
    }
}