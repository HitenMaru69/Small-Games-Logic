using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public int buttonNumber;

    public void OnClickButton()
    {
        txt.text = "X";

        GameManager.instance.CheckForWinnCondition();

    }

}
