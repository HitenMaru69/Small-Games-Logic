using System;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] CollectBrick bridge;
    public static BrickManager instance;
    private int totalBrickCollect;
    private List<GameObject> brickList = new();

    public event EventHandler RemoveBricks;

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
            Destroy(brickList[totalBrickCollect]);
            brickList.RemoveAt(totalBrickCollect);
            InvokeRemoveBrickEvent();
            
        }
        else
        {
            Destroy(brickList[0]);
            brickList.RemoveAt(0);
            bridge.ResetSpwanTransform();
        }

        
    }
    public int CheckTotalBrick()
    {
        return totalBrickCollect;
    }


    private void InvokeRemoveBrickEvent()
    {
        RemoveBricks?.Invoke(this,EventArgs.Empty);
    }
}
