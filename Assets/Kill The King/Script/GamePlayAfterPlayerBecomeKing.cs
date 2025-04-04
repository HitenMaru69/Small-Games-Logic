using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayAfterPlayerBecomeKing : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GamePlay gamePlay;
    [SerializeField] SpawnWall spawnWall;
    [SerializeField] float playerlifeTime;

    private Image image;
    private float currentLifeTime;

    private void Start()
    {
        currentLifeTime = playerlifeTime;
        EventManager.Instance.DieKingEvent += PlayerBecomeKing;
    }

   
    private void Update()
    {
        if(player.GetPlayerState() == playerState.King)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.RotatePlayer(new Vector3(0f, 180f, 0f));
                spawnWall.StopMovingWall();
                EventManager.Instance.InvokeCheckEnemyTryToKill();
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                player.RotatePlayer(new Vector3(0f, 0f, 0f));
                spawnWall.ResumeMovingWall();
                EventManager.Instance.InvokeEnemyagainTryToKill();
            }

        }
    }

    private void OnDisable()
    {
        EventManager.Instance.DieKingEvent -= PlayerBecomeKing;
    }

    IEnumerator PlayerTimeForKing()
    {
        yield return new WaitForSeconds(1);
        EventManager.Instance.InvokeStartEnemyAIEvent();
        image = gamePlay.GetSliderImage();
        image.fillAmount = 1f;
        while(currentLifeTime > 0f)
        {
            float amount = currentLifeTime / playerlifeTime;
            image.fillAmount = amount;
            currentLifeTime -= Time.deltaTime;
            yield return null;
        }

        PlayerDieAsKing();
    }

    private void PlayerDieAsKing()
    {
        Debug.Log("Player die as king");
    }

    private void PlayerBecomeKing(object sender, System.EventArgs e)
    {
        StartCoroutine(PlayerTimeForKing());
    }

}
