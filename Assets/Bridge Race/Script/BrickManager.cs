using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public static BrickManager instance;

    private int totalBrickCollect;
    private List<GameObject> brickList = new();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        totalBrickCollect = 0;
    }

    public void UpdateTotalBrickCount(GameObject obj)
    {
        totalBrickCollect += 1;
        brickList.Add(obj);
    }
    public void RemoveBrick()
    {
        totalBrickCollect -= 1;
        if (totalBrickCollect > 0)
        {
            Destroy(brickList[totalBrickCollect - 1]);
            brickList.RemoveAt(totalBrickCollect - 1);
            
        }
        else
        {
            Destroy(brickList[0]);
            brickList.RemoveAt(0);
        }
    }
    public int CheckTotalBrick()
    {
        return totalBrickCollect;
    }

}
