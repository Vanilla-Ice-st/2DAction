using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemy : MonoBehaviour
{

    private const string ENEMYTAG = "Enemy";

    private bool isHit = false;

    // 点滅させる対象をHierarchyの中のオブジェクトから選択可能？インスペクターから指定
    [SerializeField] private Renderer _target;
    // 点滅周期[s]
    [SerializeField] private float _cycle;

    private float flashTime;

    [Header("敵に接触すると減るLIFE")] public int lifeDown;

    void Update()
    {
        if (isHit)
        {
            // 内部時刻を経過させる
            flashTime += Time.deltaTime;

            // 周期cycleで繰り返す値の取得
            // 0～cycleの範囲の値が得られる
            var repeatValue = Mathf.Repeat(flashTime, _cycle);

            // 内部時刻timeにおける明滅状態を反映
            // 数値の0～1未満はfalse、1以上はtrueになるため、それで表示非表示を判断している（と思われる）
            _target.enabled = repeatValue >= _cycle * 0.5f;

            //操作不能処理
            this.gameObject.GetComponent<PlayerMove>().enabled = false;
        }
    }

    //当たり判定のあるものがぶつかる場合、↓の引数は「Collider2D」ではなく「Collision2D」の方が良いらしい
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == ENEMYTAG)
        {
            isHit = true;
            //一定回数点滅したらisHitをfalseにしたかったが、上手く出来なかったので妥協
            Invoke(("Hit"), 2.0f);
            GManager.instance.life -= lifeDown;
        }
    }

    void Hit()
    {
        isHit = false;
        // Updateに記載していたが毎秒呼び出してしまうと重くなってしまいそうと判断したため、下記はここで処理することにする。
        // 操作可能になるようにする
        this.gameObject.GetComponent<PlayerMove>().enabled = true;
        // プレイヤーが非表示のままになることがあったため対策
        _target.enabled = true;
    }

}
