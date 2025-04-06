using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    GoingForKill,
    CatchByPlayer
}
public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float enemySpeed;
    [SerializeField] GameObject knife;
    [SerializeField] float rotationSpeed;
    [SerializeField] EnemyState enemyState;
    [SerializeField] List<GameObject> enemyHat;
    [SerializeField] GameObject eyeGlass;
    [SerializeField] Transform enemyStartPos;

    private float totalTime = 10;
    private float currentTime = 0;
    private bool isGoingForKill = false;
    private int currentEnemyNumber = 0;


    private void OnEnable()
    {

        enemyState = EnemyState.GoingForKill;
        isGoingForKill = false;
        eyeGlass.SetActive(false);
        currentEnemyNumber = 0;
        currentTime = 0;
        ResetKnife();
        
        EventManager.Instance.StartEnemyAIEvent += EnemyATSpawn;
        EventManager.Instance.CheckEnemyTryToKill += OnPlayerTurn;
        EventManager.Instance.EnemyagainTryToKillEvent += AgainStartToKill;
        EventManager.Instance.SpawnNewEnemyEvent += SpawnEnemy;
        EventManager.Instance.StopEnemyAIAttckToPlayerEvnet += StopEnemyAI;
        EventManager.Instance.PlayerTimeUpAsKingEvent += ResetEnemy;
    }



    private void OnDisable()
    {
        EventManager.Instance.StartEnemyAIEvent -= EnemyATSpawn;
        EventManager.Instance.CheckEnemyTryToKill -= OnPlayerTurn;
        EventManager.Instance.EnemyagainTryToKillEvent -= AgainStartToKill;
        EventManager.Instance.SpawnNewEnemyEvent -= SpawnEnemy;
        EventManager.Instance.StopEnemyAIAttckToPlayerEvnet -= StopEnemyAI;
        EventManager.Instance.PlayerTimeUpAsKingEvent -= ResetEnemy;

    }

    [ContextMenu("Test")]
    public void Test()
    {
        StartCoroutine(GoingTowerdPlayer());
    }

    // Follow Player
    IEnumerator GoingTowerdPlayer()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);

        while (dis >= 3f)
        {
           
            transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
            dis = Vector3.Distance(transform.position, player.transform.position);
            yield return null;
        }

        StartCoroutine(TryToKillPlayer());  // Enemy Reach to the player and try to kill player
    }

    // Try To Attack Player

    IEnumerator TryToKillPlayer()
    {

        isGoingForKill = true;

        while(currentTime < totalTime)
        {
            currentTime += Time.deltaTime;
            RotateKnife();
            yield return null;
        }

        // Player Kill Functionality
 
        Player p = player.GetComponent<Player>();
        KnifePositionAfterAttack();
        p.PlayerDie();
        EventManager.Instance.InvokeStopEnemyAIAttckToPlayerEvnet();
    }

    private void RotateKnife()  // To Rotate Knife
    {
        knife.transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime);
    }

    private void KnifePositionAfterAttack()  
    {
        knife.transform.parent = player.transform;
        Vector3 newPos = knife.transform.localPosition;
        newPos.x = -2.2f;
        knife.transform.localPosition = newPos;
        knife.transform.localRotation = Quaternion.identity;
        
    }

    private void ChangeEnemy()
    {
        if (currentEnemyNumber < enemyHat.Count - 1)
        {
            currentEnemyNumber++;
        }
        else { currentEnemyNumber = 0; }

        for (int i = 0; i < enemyHat.Count; i++)
        {
            if (i == currentEnemyNumber)
            {
                enemyHat[i].SetActive(true);
            }
            else
            {
                enemyHat[i].SetActive(false);
            }
        }
    }

    private void ResetKnife()
    {
        knife.transform.parent = this.transform;
        Vector3 newPos = knife.transform.localPosition;
        newPos.x = -0.294f;
        newPos.y = 0f;
        newPos.z = 0f;
        knife.transform.localPosition = newPos;

    }

    private void EnemyATSpawn(object sender, System.EventArgs e)
    {
        StartCoroutine(GoingTowerdPlayer());
    }

    private void OnPlayerTurn(object sender, System.EventArgs e)
    {
        StopAllCoroutines();

        // Note:- In future Add Random number for the current Time 
        if (isGoingForKill && currentTime >= 3) 
        {
            Debug.Log("Player catch the enemy");
            enemyState = EnemyState.CatchByPlayer;
            EventManager.Instance.InvokeCatchKillerEvent();

        }
        else if(isGoingForKill && currentTime <= 3)
        {
            knife.transform.rotation = Quaternion.identity;
            isGoingForKill = false;
        }

    }

    // Restart To Try Kill Player If Player can not Catch Enemy
    private void AgainStartToKill(object sender, System.EventArgs e)
    {
        if (enemyState == EnemyState.GoingForKill) 
        {
            currentTime = 0;
            StartCoroutine(TryToKillPlayer());
        }

    }

    private void SpawnEnemy(object sender, System.EventArgs e)
    {
        StopAllCoroutines();
        knife.transform.rotation = Quaternion.identity;
        enemyState = EnemyState.GoingForKill;
        currentTime = 0;
        ChangeEnemy();
        StartCoroutine(GoingTowerdPlayer());
    }

    private void StopEnemyAI(object sender, System.EventArgs e)
    {
        StopAllCoroutines();
        knife.transform.localRotation = Quaternion.identity;
        isGoingForKill = false;
        StartCoroutine(EnemyBecomeKing());

    }

    IEnumerator EnemyBecomeKing()
    {
        float dis = Vector3.Distance(transform.position, player.transform.position);

        while (dis > 2.3f)
        {

            transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
            dis = Vector3.Distance(transform.position, player.transform.position);
            yield return null;

        }

        foreach(GameObject obj in enemyHat)
        {
            obj.SetActive(false);
        }
        eyeGlass.SetActive(true);
        knife.SetActive(false);
        player.gameObject.SetActive(false);
        EventManager.Instance.InvokePlayeTimeupAsKingEvent();
    }

    private void ResetEnemy(object sender, System.EventArgs e)
    {
        transform.position = enemyStartPos.position;
        eyeGlass.SetActive(false);
        knife.SetActive(true);
        this.gameObject.SetActive(false);

    }

}
