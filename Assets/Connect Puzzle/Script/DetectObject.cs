using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectObject : MonoBehaviour
{

    private string tagname = "Puzzle";
    private string matchTagName = "Match";
    private int matchNumber;
    private GameObject checkforSameObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetObject();
        }
    }

    private void GetObject()
    {
        Vector3 mousePosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity);

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == tagname || hit.collider.gameObject.tag == matchTagName)
            {
                PuzzleObject puzzleObject =  hit.collider.gameObject.GetComponent<PuzzleObject>();

                if(matchNumber <= 0)
                {
                    matchNumber += 1;
                    checkforSameObject = puzzleObject.gameObject;
                    GameManager.instance.getTransform = puzzleObject.gameObject;
                    GameManager.instance.puzzleObject.Add(puzzleObject.gameObject);
                }
                else
                {
                    CheckForSameRawObjectClick(puzzleObject.gameObject);
                    GameManager.instance.CheckForWinn();
                    
                }


            }
        }

    }

    private void CheckForSameRawObjectClick(GameObject obj)
    {
        if (checkforSameObject.tag == obj.tag) {

            matchNumber = 0;
            GameManager.instance.puzzleObject.Remove(obj.gameObject);
            GameManager.instance.puzzleObject.Remove(checkforSameObject);
            return;
        }
        else
        {
            GameManager.instance.DraeLine(obj.gameObject);
            checkforSameObject = null;
            matchNumber = 0;
            GameManager.instance.matchObjects.Add(obj.gameObject);
        }
    }



}
