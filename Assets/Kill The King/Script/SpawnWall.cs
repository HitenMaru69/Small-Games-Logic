using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnWall : MonoBehaviour
{
    [SerializeField] List<GameObject> walls;

    private void Update()
    {
        RemoveWall();
    }

    public void StopMovingWall()
    {
        foreach (GameObject wall in walls) { 
        
            MovingWall movingWall = wall.GetComponent<MovingWall>();
            movingWall.StopMovingWall();
        }
    }

    public void ResumeMovingWall()
    {
        foreach (GameObject wall in walls)
        {
            MovingWall movingWall = wall.GetComponent<MovingWall>();
            movingWall.ResumeMovingWall();
        }
    }

    private void RemoveWall()
    {
        GameObject firstObject = walls[0];
        if(firstObject != null)
        {
            if(firstObject.transform.position.x <= -40)
            {
                walls[0].gameObject.SetActive(false);
                SetNewPositionOfRemoveObject(firstObject);
                walls.Remove(firstObject);
            }
        }
    }

    private void SetNewPositionOfRemoveObject(GameObject obj)
    {
        Transform lastObjectPosition = walls[walls.Count-1].gameObject.transform;
        if (lastObjectPosition != null)
        {
            Vector3 newPos = lastObjectPosition.position;
            newPos.x = lastObjectPosition.position.x + 23f;
            obj.transform.position = newPos;
            walls.Add(obj);
            obj.SetActive(true);
        }
    }
}
