using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    //scene一覧をここに記入し、ボタン押下による遷移を一括管理
    public const string SCENE01 = "TitleScene";
    public const string SCENE02 = "Demo";
    public const string SCENE03 = "ResultScene";

    public void SwitchSceneToGame()
    {
        //ゲーム開始時にスコアとライフの初期化
        Score.ScoreReset();
        PlayerLife.LifeReset();
        SceneManager.LoadScene(SCENE02, LoadSceneMode.Single);
    }

    public void SwitchSceneToResult()
    {
        SceneManager.LoadScene(SCENE03, LoadSceneMode.Single);
    }

    public void SwitchSceneToTitle()
    {
        SceneManager.LoadScene(SCENE01, LoadSceneMode.Single);
    }
}