using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//参考https://dkrevel.com/makegame-beginner/make-2d-action-game-manager/
public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    // ①シングルトンのものは基本HideInInspectorで隠す
    [HideInInspector]
    public int score = 0;
    [HideInInspector]
    public int life = 0;

    // ②もしくはプロパティにする等、インスペクターで弄れ無い方がいいものもある。こういうのはプログラムによるけど他の作業者弄られたくないものは隠す
    //public int Score { get; set; } = 0;
    //public int Life = 0;

    //AwakeはStartより先に処理されるメソッド
    private void Awake()
    {
        if (instance == null)
        {
            //8行目で確保したメモリに自身のインスタンスを入れる
            instance = this;
            //scene切り替え時にこのスクリプトが付与されているオブジェクトを破棄されないようにする
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        // ビルドでの表示速度を決めるflame設定。startはスクリプトの順番を問わず全てのスクリプトで最初に読み込まれるため暫定でここに記載
        Application.targetFrameRate = 60;
    }
}