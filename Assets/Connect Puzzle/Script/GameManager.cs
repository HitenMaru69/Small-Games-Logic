using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject getTransform;
    public List<GameObject> puzzleObject =  new ();
    public List<GameObject> matchObjects = new();

    private int TotalMatch = 6; // You can add dinmamically by making puzzle and add them in Scriptable Object

    private void Awake()
    {
        instance = this;
    }

    public void DraeLine(GameObject obj)
    {
        LineRenderer lineRenderer =  getTransform.AddComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.SetPosition(0,getTransform.transform.position);
        lineRenderer.SetPosition(1,obj.transform.position);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.enabled = true;

    }

    public void CheckForWinn()
    {
        if (puzzleObject.Count + matchObjects.Count != TotalMatch) { return; }

        int count = 0;

        for (int i = 0; i < puzzleObject.Count; i++)
        {
            PuzzleObject puzzleObject1 = puzzleObject[i].GetComponent<PuzzleObject>();
            PuzzleObject puzzleObject2 = matchObjects[i].GetComponent<PuzzleObject>();


            if (puzzleObject1.GetPuzzleObjectNumber() == puzzleObject2.GetPuzzleObjectNumber())
            {
                count++;
            }
        }

        if (count >= TotalMatch/2)
        {

            Debug.Log("You winn");
        }
        else
        {
            Debug.Log("lose");
        }


    }
}
