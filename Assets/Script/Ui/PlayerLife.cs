using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    private Text lifeText;
    private int oldLife = 0;
    public static int DEFAULTLIFE = 3;

    void Start()
    {
        lifeText = GetComponent<Text>();
        if (GManager.instance != null)
        {
            lifeText.text = "LIFE Å~ " + GManager.instance.life;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (oldLife != GManager.instance.life)
        {
            lifeText.text = "LIFE Å~ " + GManager.instance.life;
            oldLife = GManager.instance.life;
        }
    }
    public static void LifeReset()
    {
        //ÉXÉRÉAèâä˙âª
        GManager.instance.life = DEFAULTLIFE;
    }
}