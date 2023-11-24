using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    // ゴールにプレイヤーが接触する
    [HideInInspector] public bool isGoal = false;
    private const string PLAYERTAG = "Player";

    // シーン遷移するボタンクリックのスクリプトを呼び出し
    public SceneChangeButton sceneChangeButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(PLAYERTAG))
        {
            StartCoroutine("DelaySceneChange");
        }
    }

    //ゴール後に一瞬遅らせてからゴールする処理を行う
    private IEnumerator DelaySceneChange()
    {
        float start = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup - start < 1)
        {
            yield return null;
        }

        sceneChangeButton.SwitchSceneToResult();
    }
}
