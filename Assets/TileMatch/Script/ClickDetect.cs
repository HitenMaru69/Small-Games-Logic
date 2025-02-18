using UnityEngine;
using UnityEngine.UI;

public class ClickDetect : MonoBehaviour
{
    public int number;

    [SerializeField] Image image;
    RectTransform rectTransforms;


    private void Awake()
    {
        rectTransforms = GetComponent<RectTransform>();
    }

    public void OnClickImage()
    {

    }
}
