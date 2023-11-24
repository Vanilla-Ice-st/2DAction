using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSE : MonoBehaviour
{
    private string COINTAG = "Coin";

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == COINTAG)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}