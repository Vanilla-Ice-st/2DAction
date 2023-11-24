using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    private string TORESULTBUTTON = "ToResultButton";

    public GameObject buttonActive;

    private string PLAYER = "Player";
    public GameObject player;
    public PlayerMove playerOut;

    // Start is called before the first frame update
    void Start()
    {
        this.buttonActive = GameObject.Find(TORESULTBUTTON);
        this.buttonActive.SetActive(false);
        player = GameObject.Find(PLAYER);
        playerOut = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOut.isOut)
        {
            this.buttonActive.SetActive(true);
        }
    }
}