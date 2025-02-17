using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    [SerializeField]private int puzzleMatchNumber;


    public int GetPuzzleObjectNumber()
    {
        return puzzleMatchNumber;
    }

}
