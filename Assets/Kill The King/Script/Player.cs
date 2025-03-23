using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject king;
    [SerializeField] float playerSpeed;
    [SerializeField] GameObject knife;
    [SerializeField] float knifeRotateSpeed;

    private float distance;
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
        distanceBetweenPlayerAndKing = 0.5f;
        StartCoroutine(MovePlayerTowordsTheKing());
        king.SetActive(false);
    }

    public void RotateKnife()
    {
        knife.transform.Rotate(0, 0, 1 * knifeRotateSpeed * Time.deltaTime);
    }

    public void ResetKnifeValue()
    {
        knife.transform.rotation = Quaternion.identity;
    }
}
