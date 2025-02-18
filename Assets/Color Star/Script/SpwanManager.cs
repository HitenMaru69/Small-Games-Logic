using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public static SpwanManager instance;

    [SerializeField] private List<GameObject> spwanPoint;
    [SerializeField] private List <int> spwanWaypoints;
    [SerializeField] private GameObject spwanObject;
    private int totalBall;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Invoke(nameof(SpwanBall),0.5f);
    }


    public void RemoveTotalBall()
    {
        totalBall--;

        if (totalBall <= 0) {

            SpwanBall();

        }
    }



    private void SpwanBall()
    {
        spwanWaypoints.Clear();

        int randomnumber = Random.Range(3, 6);

        totalBall = randomnumber;
        
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
        int randomSpwanPoint;
        do
        {
            randomSpwanPoint = Random.Range(0, spwanPoint.Count);
        }
        while(spwanWaypoints.Contains(randomSpwanPoint));

        spwanWaypoints.Add(randomSpwanPoint);
        return randomSpwanPoint;

    }


}
