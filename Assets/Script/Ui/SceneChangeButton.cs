using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    //scene�ꗗ�������ɋL�����A�{�^�������ɂ��J�ڂ��ꊇ�Ǘ�
    public const string SCENE01 = "TitleScene";
    public const string SCENE02 = "Demo";
    public const string SCENE03 = "ResultScene";

    public void SwitchSceneToGame()
    {
        //�Q�[���J�n���ɃX�R�A�ƃ��C�t�̏�����
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