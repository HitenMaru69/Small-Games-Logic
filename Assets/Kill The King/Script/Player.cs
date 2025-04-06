using System.Collections;
using UnityEngine;

public enum playerState
{
    Player,
    King,
    Die
}

public class Player : MonoBehaviour
{
    [SerializeField] GameObject king;
    [SerializeField] float playerSpeed;
    [SerializeField] GameObject knife;
    [SerializeField] GameObject eye;
    [SerializeField] float knifeRotateSpeed;
    [SerializeField] Transform playrStartPos;

    private float distance;
    private float distanceBetweenPlayerAndKing = 4;
    private bool isKingAlive;

    [Space(10)]
    [Header("For Player State")]
    [Header("After player become king")]
    [SerializeField] playerState state;
    [SerializeField] SpawnWall spawnWall;

    

    private void OnEnable()
    {
        ResetPlayer();
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

    public void SetPlayerState(playerState playerState)
    {
        state = playerState;
    }

    public void PlayerDie()
    {
        state = playerState.Die;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        Vector3 playerPos = transform.position;
        playerPos.z = playerPos.z + 2;
        transform.position = playerPos;
    }

    IEnumerator MovePlayerTowordsTheKing()
    {
        while (distance >= distanceBetweenPlayerAndKing)
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, king.transform.position);
            yield return null;
        }


        if (!isKingAlive) 
        {
            state = playerState.King;
            knife.gameObject.SetActive(false);
            eye.gameObject.SetActive(true);
            spawnWall.ResumeMovingWall();
            king.SetActive(false);
        }


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

    private void ResetPlayer()
    {
        StopAllCoroutines();
        transform.position = playrStartPos.position;
        transform.rotation = Quaternion.identity;
        state = playerState.Player;
        ResetKnife();
        eye.gameObject.SetActive(false);
        knife.SetActive(true);
        isKingAlive = true;
        distanceBetweenPlayerAndKing = 4;


    }

    private void ResetKnife()
    {
        knife.transform.parent = this.transform;
        Vector3 newPos = knife.transform.localPosition;
        newPos.x = -0.294f;
        newPos.y = 0f;
        newPos.z = 0f;
        knife.transform.localPosition = newPos;
        knife.transform.localRotation = Quaternion.identity;

    }

    private void OnkillKing(object sender, System.EventArgs e)
    {
        distanceBetweenPlayerAndKing = 2.1f;
        AttactWithKnife();
        isKingAlive = false;
        StartCoroutine(MovePlayerTowordsTheKing());
        EventManager.Instance.InvokeDieKingEvent();
    }


}
