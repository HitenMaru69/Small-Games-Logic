using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float enemySpeed;
    [SerializeField] GameObject knife;
    [SerializeField] float rotationSpeed;


    private float totalTime = 10;
    private float currentTime = 0;
    private bool isGoingForKill = false;


    private void OnEnable()
    {
        EventManager.Instance.CheckEnemyTryToKill += OnPlayerTurn;
        EventManager.Instance.EnemyagainTryToKillEvent += AgainStartToKill; ;
    }


    private void OnDisable()
    {
        EventManager.Instance.CheckEnemyTryToKill -= OnPlayerTurn;
        EventManager.Instance.EnemyagainTryToKillEvent -= AgainStartToKill;
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
        player.transform.rotation = Quaternion.Euler(0, 0, -90);
        knife.transform.localRotation = Quaternion.identity;
    }

    private void OnPlayerTurn(object sender, System.EventArgs e)
    {
        StopAllCoroutines();

        // Note:- In future Add Random number for the current Time 
        if (isGoingForKill && currentTime >= 3) 
        {
            Debug.Log("Player catch the enemy");
        }
        else if(isGoingForKill && currentTime <= 3)
        {
            knife.transform.rotation = Quaternion.identity;
            isGoingForKill = false;
        }

    }

    private void AgainStartToKill(object sender, System.EventArgs e)
    {
        currentTime = 0;
        StartCoroutine(TryToKillPlayer());
    }
    
}
