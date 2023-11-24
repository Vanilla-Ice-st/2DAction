using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

[RequireComponent(typeof(CircleCollider2D))]
public class PlayerMove : MonoBehaviour
{

    [Header("プレイヤーの左右の移動速度"), Tooltip("プレイヤーの左右の移動速度")]
    public float speed = 5.0f;

    [Header("プレイヤーの左右の移動時間"), Tooltip("プレイヤーの左右の移動時間")]
    public float duration = 1.0f;

    [Header("プレイヤーのジャンプ力"), Tooltip("プレイヤーのジャンプ力")]
    public float jumpPower = 240f;

    //アニメーターの真偽値の名称が変わる場合はここで変更する
    private const string PLAYER_RUN = "playerRun";
    private const string PLAYER_JUMP = "playerJump";

    //プレイヤーのスピード（調整用ですが使用していないのでコメントアウト）
    //private const float PLAYER_SPEED = 0.1f;

    //タグ「Floor」に接触しているときにジャンプ回数が復活
    private const string FLOOR = "Floor";

    //タグ「StageOut」に接触するとゴール処理
    private const string STAGEOUT = "StageOut";
    public bool isOut = false;

    //地面に接触しているときのみジャンプできるようにする
    public bool isJump = false;
    private bool isRun = false;
    private Animator anim = null;
    private Rigidbody2D rbody2D;

    private void Start()
    {
        //GetComponentは付与されているオブジェクトの情報を取得している
        anim = GetComponent<Animator>();
        rbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //移動
        Move();

        //ジャンプ
        Jump();

        //アニメーション制御
        AnimationControl();
    }

    private void Move()
    {
        //キーが押されている間なのかを☑している
        //移動ってそもそもキーが押されている間の情報が欲しいのか？⇒入力値が欲しくないですか
        //入力値を取るメソッドがunityには用意されてます
        float h = Input.GetAxis("Horizontal");
        //案① 位置情報を直接制御する方法(座標をワープして移動してるイメージなので、入力値を小さくしないと違和感がすごい）
        //transform.Translate(new Vector3(h * PLAYER_SPEED * speed, 0, 0));

        //案②　物理演算でオブジェクトの位置を制御する（案①の数値をそのまま使うと小さすぎて動いてないように見えるから注意）
        rbody2D.velocity = new Vector2(h * speed, rbody2D.velocity.y);

        //接地していてかつ、移動しているときに条件をONにする
        //h==1にすると移動はじめの0.3秒程度アニメーションが切り替わらないので、暫定でこのような処理にした
        if (isJump == true && h > 0)
        {
            isRun = true;
            transform.localScale = new Vector2(1, 1);
        }
        else if (isJump == true && h < 0)
        {
            isRun = true;
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            isRun = false;
        }

        //案③ ジャンプの挙動も変える必要あり　特殊な方法
        //Vector2 pos = new Vector2(transform.position.x + (h * speed), transform.position.y);
        //transform.DOMove(pos, duration);

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump)
            {
                this.rbody2D.AddForce(transform.up * jumpPower);
                isJump = false;
            }
        }
    }

    private void AnimationControl()
    {
        anim.SetBool(PLAYER_JUMP, !isJump);
        anim.SetBool(PLAYER_RUN, isRun);
    }

    //Floorタグがついた地面に接触しているときのみジャンプできる
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(FLOOR))
        {
            isJump = true;
        }
    }

    //StageOutタグに接触するとゴール処理を行う
    //isTriggerのチェックがあるとすり抜ける。
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(STAGEOUT))
        {
            isOut = true;
        }
    }
}