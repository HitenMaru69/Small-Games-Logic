using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    [SerializeField] private List<GameObject> totalBox;
    [SerializeField] private List<GameObject> selectedObject = new();
    

    private void Awake()
    {
        instance = this;
    }

    public void AddObjectToTheList(GameObject obj)
    {
        selectedObject.Add(obj);
        MoveObject();
    }

    public void MoveObject()
    {
        for (int i = 0; i < selectedObject.Count; i++)
        {
            RectTransform rectTransform1 = totalBox[i].GetComponent<RectTransform>();
            RectTransform rectTransform2 = selectedObject[i].GetComponent<RectTransform>();

            if (rectTransform2.anchoredPosition != rectTransform1.anchoredPosition)
            {
                rectTransform2.anchoredPosition = rectTransform1.anchoredPosition;
            }
        }
    }

    public void CheckForMatch()
    {

    }
}
