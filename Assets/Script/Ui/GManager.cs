using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Q�lhttps://dkrevel.com/makegame-beginner/make-2d-action-game-manager/
public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    // �@�V���O���g���̂��̂͊�{HideInInspector�ŉB��
    [HideInInspector]
    public int score = 0;
    [HideInInspector]
    public int life = 0;

    // �A�������̓v���p�e�B�ɂ��铙�A�C���X�y�N�^�[�ŘM�ꖳ�������������̂�����B���������̂̓v���O�����ɂ�邯�Ǒ��̍�ƎҘM��ꂽ���Ȃ����͉̂B��
    //public int Score { get; set; } = 0;
    //public int Life = 0;

    //Awake��Start����ɏ�������郁�\�b�h
    private void Awake()
    {
        if (instance == null)
        {
            //8�s�ڂŊm�ۂ����������Ɏ��g�̃C���X�^���X������
            instance = this;
            //scene�؂�ւ����ɂ��̃X�N���v�g���t�^����Ă���I�u�W�F�N�g��j������Ȃ��悤�ɂ���
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        // �r���h�ł̕\�����x�����߂�flame�ݒ�Bstart�̓X�N���v�g�̏��Ԃ��킸�S�ẴX�N���v�g�ōŏ��ɓǂݍ��܂�邽�ߎb��ł����ɋL��
        Application.targetFrameRate = 60;
    }
}