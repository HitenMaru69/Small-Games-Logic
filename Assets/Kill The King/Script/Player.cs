using System.Collections;
using UnityEngine;

public enum playerState
{
    Player,
    King
}

public class Player : MonoBehaviour
{
    [SerializeField] GameObject king;
    [SerializeField] float playerSpeed;
    [SerializeField] GameObject knife;
    [SerializeField] GameObject eye;
    [SerializeField] float knifeRotateSpeed;
    [SerializeField] private float distance;

    private float distanceBetweenPlayerAndKing = 4;

    [Space(10)]
    [Header("For Player State")]
    [Header("After player become king")]
    [SerializeField] playerState state;
    [SerializeField] SpawnWall spawnWall;

    

    private void Start()
    {
        state = playerState.Player;
        distance = Vector3.Distance(transform.position, king.transform.position);
        StartCoroutine(MovePlayerTowordsTheKing());

        EventManager.Instance.KillKingEvent += OnkillKing;
    }


    private void OnDisable()
    {
        EventManager.Instance.KillKingEvent -= OnkillKing;
    }

    public void RotateKnife()
    {
        knife.transform.Rotate(0, 0, 1 * knifeRotateSpeed * Time.deltaTime);
    }

    public void ResetKnifeValue()
    {
        knife.transform.rotation = Quaternion.identity;
    }

    public void RotatePlayer(Vector3 dir)
    {
        transform.rotation = Quaternion.Euler(dir);
    }

    public playerState GetPlayerState()
    {
        return state;
    }

    IEnumerator MovePlayerTowordsTheKing()
    {
        while (distance >= distanceBetweenPlayerAndKing)
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, king.transform.position);
            yield return null;
        }

        if(state == playerState.King)
        {
            knife.gameObject.SetActive(false);
            eye.gameObject.SetActive(true);
            spawnWall.ResumeMovingWall();
            king.SetActive(false);
        }

    }

    private void OnkillKing(object sender, System.EventArgs e)
    {
        distanceBetweenPlayerAndKing = 2.1f;
        AttactWithKnife();
        state = playerState.King;
        StartCoroutine(MovePlayerTowordsTheKing());
        EventManager.Instance.InvokeDieKingEvent();
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
