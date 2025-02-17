using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public int buttonNumber;

    public void OnClickButton()
    {

        txt.text = GameManager.instance.SetPlayerSideTxt();
        GameManager.instance.CheckForWinnCondition();
        GameManager.instance.ChangeTurn();


    }

}
