using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDelete : MonoBehaviour
{
    // îªíËì‡Ç…ÉvÉåÉCÉÑÅ[Ç™Ç¢ÇÈ
    [HideInInspector] public bool isOn = false;
    private const string PLAYERTAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PLAYERTAG)
        {
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PLAYERTAG)
        {
            isOn = false;
        }
    }
}
