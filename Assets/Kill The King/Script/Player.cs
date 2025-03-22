using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject king;
    [SerializeField] float playerSpeed;

    private const int distanceBetweenPlayerAndKing = 4;
    float distance ;

    private void Start()
    {
        distance = Vector3.Distance(transform.position, king.transform.position);
        StartCoroutine(MovePlayerTowordsTheKing());
    }

    IEnumerator MovePlayerTowordsTheKing()
    {
        while (distance >= distanceBetweenPlayerAndKing)
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, king.transform.position);
            yield return null;
        }

    }
}
