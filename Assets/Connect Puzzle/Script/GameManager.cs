using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject getTransform;
    public List<GameObject> puzzleObject =  new ();
    public List<GameObject> matchObjects = new();

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
        int count = 0;
        if (puzzleObject.Count >= 3 && matchObjects.Count >= 3)
        {
            for(int i = 0; i < puzzleObject.Count; i++)
            {
                PuzzleObject puzzleObject1 = puzzleObject[i].GetComponent<PuzzleObject>();
                PuzzleObject puzzleObject2 = matchObjects[i].GetComponent<PuzzleObject>();
                

                if(puzzleObject1.GetPuzzleObjectNumber() == puzzleObject2.GetPuzzleObjectNumber())
                {
                    count++;
                }
            }

            if (count >= 3) {

                Debug.Log("You winn");
            }
            else
            {
                Debug.Log("lose");
            }
        }
    }
}
