using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> spwanPoint;
    [SerializeField] private List <int> spwanWaypoints;
    [SerializeField] private GameObject spwanObject;


    private void Start()
    {
        Invoke(nameof(SpwanBall),0.5f);
    }

    private void SpwanBall()
    {
        spwanWaypoints.Clear();

        int randomnumber = Random.Range(1, 4);
        
        for (int i = 0; i < randomnumber; i++)
        {
            GetRandomNumber();

        }

        for (int j = 0; j < spwanWaypoints.Count; j++)
        {
            Instantiate(spwanObject, spwanPoint[spwanWaypoints[j]].transform.position, Quaternion.identity);
        }

    }

    private int GetRandomNumber()
    {
        int randomSpwanPoint = Random.Range(0, spwanPoint.Count);
        if (spwanWaypoints.Contains(randomSpwanPoint))
        {
            GetRandomNumber();
        }
        else
        {
            spwanWaypoints.Add(randomSpwanPoint);
        }

        return randomSpwanPoint;
    }


}
