using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    [Header("���Z����X�R�A")] public int myScore;
    [Header("�v���C���[�̔���")] public CoinDelete playerCheck;

    private void Start()
    {
        playerCheck = GetComponent<CoinDelete>();
    }

    void Update()
    {
        //�v���C���[��������ɓ�������
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