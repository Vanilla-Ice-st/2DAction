using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    [Header("加算するスコア")] public int myScore;
    [Header("プレイヤーの判定")] public CoinDelete playerCheck;

    private void Start()
    {
        playerCheck = GetComponent<CoinDelete>();
    }

    void Update()
    {
        //プレイヤーが判定内に入ったら
        if (playerCheck.isOn)
        {
            if (GManager.instance != null)
            {
                GManager.instance.score += myScore;
                Destroy(this.gameObject);
            }
        }
    }
}