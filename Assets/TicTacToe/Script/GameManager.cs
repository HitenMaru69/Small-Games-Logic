using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Block> buttonList;

    private string sidePlayer;


    public bool isOPlayerTurn;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isOPlayerTurn = true;
    }

    public void CheckForWinnCondition()
    {
        // Raw Check

        if (buttonList[0].txt.text == sidePlayer && buttonList[1].txt.text == sidePlayer && buttonList[2].txt.text == sidePlayer)
        {
            Debug.Log("GameWinn" + sidePlayer);
            return;
        }
        if (buttonList[3].txt.text == sidePlayer && buttonList[4].txt.text == sidePlayer && buttonList[5].txt.text == sidePlayer)
        {
            Debug.Log("GameWinn" + sidePlayer);
            return;
        }
        if (buttonList[6].txt.text == sidePlayer && buttonList[7].txt.text == sidePlayer && buttonList[8].txt.text == sidePlayer)
        {
            Debug.Log("GameWinn" + sidePlayer);
            return;
        }


        //Coloum Check

        if (buttonList[0].txt.text == sidePlayer && buttonList[3].txt.text == sidePlayer && buttonList[6].txt.text == sidePlayer)
        {
            Debug.Log("GameWinn" + sidePlayer);
            return;
        }
        if (buttonList[1].txt.text == sidePlayer && buttonList[4].txt.text == sidePlayer && buttonList[7].txt.text == sidePlayer)
        {
            Debug.Log("GameWinn" + sidePlayer);
            return;
        }
        if (buttonList[2].txt.text == sidePlayer && buttonList[5].txt.text == sidePlayer && buttonList[8].txt.text == sidePlayer)
        {
            Debug.Log("GameWinn" + sidePlayer);
            return;
        }

        //diogonal check

        if (buttonList[0].txt.text == sidePlayer && buttonList[4].txt.text == sidePlayer && buttonList[8].txt.text == sidePlayer)
        {
            Debug.Log("GameWinn" + sidePlayer);
            return;
        }
        if (buttonList[2].txt.text == sidePlayer && buttonList[4].txt.text == sidePlayer && buttonList[6].txt.text == sidePlayer)
        {
            Debug.Log("GameWinn" + sidePlayer);
            return;
        }
    }

    public bool ChangeTurn()
    {
        if (isOPlayerTurn) { return isOPlayerTurn = false; }
        if (!isOPlayerTurn) { return isOPlayerTurn = true; }

        return isOPlayerTurn;
    }

    public string SetPlayerSideTxt()
    {
        if (isOPlayerTurn)
        {

            return sidePlayer = "O";
        }
        else
        {
            return sidePlayer = "X";
        }
    }
}
