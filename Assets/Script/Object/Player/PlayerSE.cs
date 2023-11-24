using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : MonoBehaviour
{
    public PlayerMove playerMove;

    void Update()
    {
        if (playerMove.isJump)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}