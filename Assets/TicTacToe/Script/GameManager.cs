using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Block> buttonList;


    private void Awake()
    {
        instance = this;
    }

    public void CheckForWinnCondition()
    { 
        // Raw Check

        if (buttonList[0].txt.text == "X" && buttonList[1].txt.text == "X" && buttonList[2].txt.text == "X")
        {
            Debug.Log("GameWinn");
        }
        if (buttonList[3].txt.text == "X" && buttonList[4].txt.text == "X" && buttonList[5].txt.text == "X")
        {
            Debug.Log("GameWinn");
        }
        if (buttonList[6].txt.text == "X" && buttonList[7].txt.text == "X" && buttonList[8].txt.text == "X")
        {
            Debug.Log("GameWinn");
        }


        //Coloum Check

        if (buttonList[0].txt.text == "X" && buttonList[3].txt.text == "X" && buttonList[6].txt.text == "X")
        {
            Debug.Log("GameWinn");
        }
        if (buttonList[1].txt.text == "X" && buttonList[4].txt.text == "X" && buttonList[7].txt.text == "X")
        {
            Debug.Log("GameWinn");
        }
        if (buttonList[2].txt.text == "X" && buttonList[5].txt.text == "X" && buttonList[8].txt.text == "X")
        {
            Debug.Log("GameWinn");
        }

        //diogonal check

        if (buttonList[0].txt.text == "X" && buttonList[4].txt.text == "X" && buttonList[8].txt.text == "X")
        {
            Debug.Log("GameWinn");
        }
        if (buttonList[2].txt.text == "X" && buttonList[4].txt.text == "X" && buttonList[6].txt.text == "X")
        {
            Debug.Log("GameWinn");
        }
    }

  
}
