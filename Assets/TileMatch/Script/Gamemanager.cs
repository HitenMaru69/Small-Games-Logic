using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    [SerializeField] private List<GameObject> totalBox;
    private List<GameObject> selectedObject = new();
    private List<GameObject> destroyObject = new();


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
        if (selectedObject.Count <= totalBox.Count)
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

    }

    public void CheckForMatch(GameObject obj)
    {
        if (selectedObject.Count >= totalBox.Count)
        {
            Debug.Log("You Lose ");
            return;
        }

        destroyObject.Clear();

        ClickDetect clickDetect = obj.GetComponent<ClickDetect>();

        int number = clickDetect.number;

        int count = 0;

        for(int i = 0; i < selectedObject.Count; i++)
        {

            ClickDetect clickDetect1 = selectedObject[i].GetComponent<ClickDetect>();

            if(clickDetect1.number == number)
            {
                count++;
                if (!destroyObject.Contains(selectedObject[i]))
                {
                    destroyObject.Add(selectedObject[i]);
                }
            }
            
            if(count >= 3)
            {
                selectedObject.RemoveAll(obj=>obj.GetComponent<ClickDetect>().number == number);

                for (int j = 0; j < destroyObject.Count; j++)
                {
                    ClickDetect clickDetect2 = destroyObject[j].GetComponent<ClickDetect>();

                    if (clickDetect2.number == number)
                    {
                        Destroy(clickDetect2.gameObject);
                    }
                }

                Invoke(nameof(MoveObject), 0.5f);

            }
        }
    }

    
}
