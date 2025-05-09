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

        int[,] winconditionArray = new int[,]
        {
            { 0,1,2 },
            { 3,4,5 },
            { 6,7,8 },
            { 0,3,6 },
            { 1,4,7 },
            { 2,5,8 },
            { 0,4,8 },
            { 2,4,6 },

        };

        for (int i = 0; i < winconditionArray.GetLength(0); i++) {

            if (buttonList[winconditionArray[i, 0]].txt.text == sidePlayer &&
                buttonList[winconditionArray[i, 1]].txt.text == sidePlayer &&
                buttonList[winconditionArray[i, 2]].txt.text == sidePlayer)
            {
                Debug.Log("GameWinn" + sidePlayer);
                return;
            }
        }


        //// Raw Check

        //if (buttonList[0].txt.text == sidePlayer && buttonList[1].txt.text == sidePlayer && buttonList[2].txt.text == sidePlayer)
        //{
        //    Debug.Log("GameWinn" + sidePlayer);
        //    return;
        //}
        //if (buttonList[3].txt.text == sidePlayer && buttonList[4].txt.text == sidePlayer && buttonList[5].txt.text == sidePlayer)
        //{
        //    Debug.Log("GameWinn" + sidePlayer);
        //    return;
        //}
        //if (buttonList[6].txt.text == sidePlayer && buttonList[7].txt.text == sidePlayer && buttonList[8].txt.text == sidePlayer)
        //{
        //    Debug.Log("GameWinn" + sidePlayer);
        //    return;
        //}


        ////Coloum Check

        //if (buttonList[0].txt.text == sidePlayer && buttonList[3].txt.text == sidePlayer && buttonList[6].txt.text == sidePlayer)
        //{
        //    Debug.Log("GameWinn" + sidePlayer);
        //    return;
        //}
        //if (buttonList[1].txt.text == sidePlayer && buttonList[4].txt.text == sidePlayer && buttonList[7].txt.text == sidePlayer)
        //{
        //    Debug.Log("GameWinn" + sidePlayer);
        //    return;
        //}
        //if (buttonList[2].txt.text == sidePlayer && buttonList[5].txt.text == sidePlayer && buttonList[8].txt.text == sidePlayer)
        //{
        //    Debug.Log("GameWinn" + sidePlayer);
        //    return;
        //}

        ////diogonal check

        //if (buttonList[0].txt.text == sidePlayer && buttonList[4].txt.text == sidePlayer && buttonList[8].txt.text == sidePlayer)
        //{
        //    Debug.Log("GameWinn" + sidePlayer);
        //    return;
        //}
        //if (buttonList[2].txt.text == sidePlayer && buttonList[4].txt.text == sidePlayer && buttonList[6].txt.text == sidePlayer)
        //{
        //    Debug.Log("GameWinn" + sidePlayer);
        //    return;
        //}
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
