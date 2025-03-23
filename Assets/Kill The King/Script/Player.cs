using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject king;
    [SerializeField] float playerSpeed;
    [SerializeField] GameObject knife;
    [SerializeField] float knifeRotateSpeed;

    [SerializeField]private float distance;
    private float distanceBetweenPlayerAndKing = 4;
 
    private void Start()
    {
        distance = Vector3.Distance(transform.position, king.transform.position);
        StartCoroutine(MovePlayerTowordsTheKing());

        EventManager.Instance.KillKingEvent += OnkillKing;
    }


    private void OnDisable()
    {
        EventManager.Instance.KillKingEvent -= OnkillKing;
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

    private void OnkillKing(object sender, System.EventArgs e)
    {
        distanceBetweenPlayerAndKing = 2.1f;
        AttactWithKnife();
        StartCoroutine(MovePlayerTowordsTheKing());
        EventManager.Instance.InvokeDieKingEvent();
    }

    public void RotateKnife()
    {
        knife.transform.Rotate(0, 0, 1 * knifeRotateSpeed * Time.deltaTime);
    }

    public void ResetKnifeValue()
    {
        knife.transform.rotation = Quaternion.identity;
    }

    private void AttactWithKnife()
    {
        knife.transform.parent = king.transform;
        Vector3 newPos = knife.transform.localPosition;
        newPos.x = -2.2f;
        knife.transform.localPosition = newPos;
        king.transform.rotation = Quaternion.Euler(0, 0, -90);
        knife.transform.localRotation = Quaternion.identity;
    }

}
