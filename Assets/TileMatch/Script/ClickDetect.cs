using UnityEngine;
using UnityEngine.UI;

public class ClickDetect : MonoBehaviour
{
    public int number;

    public void OnClickImage()
    {    
        Gamemanager.instance.AddObjectToTheList(gameObject);
        Gamemanager.instance.CheckForMatch(gameObject);
    }
}
