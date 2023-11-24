using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemy : MonoBehaviour
{

    private const string ENEMYTAG = "Enemy";

    private bool isHit = false;

    // �_�ł�����Ώۂ�Hierarchy�̒��̃I�u�W�F�N�g����I���\�H�C���X�y�N�^�[����w��
    [SerializeField] private Renderer _target;
    // �_�Ŏ���[s]
    [SerializeField] private float _cycle;

    private float flashTime;

    [Header("�G�ɐڐG����ƌ���LIFE")] public int lifeDown;

    void Update()
    {
        if (isHit)
        {
            // �����������o�߂�����
            flashTime += Time.deltaTime;

            // ����cycle�ŌJ��Ԃ��l�̎擾
            // 0�`cycle�͈̔͂̒l��������
            var repeatValue = Mathf.Repeat(flashTime, _cycle);

            // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
            // ���l��0�`1������false�A1�ȏ��true�ɂȂ邽�߁A����ŕ\����\���𔻒f���Ă���i�Ǝv����j
            _target.enabled = repeatValue >= _cycle * 0.5f;

            //����s�\����
            this.gameObject.GetComponent<PlayerMove>().enabled = false;
        }
    }

    //�����蔻��̂�����̂��Ԃ���ꍇ�A���̈����́uCollider2D�v�ł͂Ȃ��uCollision2D�v�̕����ǂ��炵��
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == ENEMYTAG)
        {
            isHit = true;
            //���񐔓_�ł�����isHit��false�ɂ������������A��肭�o���Ȃ������̂őË�
            Invoke(("Hit"), 2.0f);
            GManager.instance.life -= lifeDown;
        }
    }

    void Hit()
    {
        isHit = false;
        // Update�ɋL�ڂ��Ă��������b�Ăяo���Ă��܂��Əd���Ȃ��Ă��܂������Ɣ��f�������߁A���L�͂����ŏ������邱�Ƃɂ���B
        // ����\�ɂȂ�悤�ɂ���
        this.gameObject.GetComponent<PlayerMove>().enabled = true;
        // �v���C���[����\���̂܂܂ɂȂ邱�Ƃ����������ߑ΍�
        _target.enabled = true;
    }

}
