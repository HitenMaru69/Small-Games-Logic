using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GardType
{
    Main,
    Normal
}

public class Gards : MonoBehaviour
{

    [SerializeField] Transform startPos;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject enemygameObject;
    [SerializeField] float gardMoveSpeed;
    [SerializeField] GardType gardType;

    private GameObject catchObject;
    private bool isMoveToCatchPlayer;
    private float dis;
    private Player playerscript;
    private void Start()
    {
        isMoveToCatchPlayer = false;
        playerscript = FindAnyObjectByType<Player>();
        EventManager.Instance.CatchKillerEvent += MoveToCatchPlayer;
    }


    private void OnDisable()
    {
        EventManager.Instance.CatchKillerEvent -= MoveToCatchPlayer;
    }


    IEnumerator MoveTothePlayer()
    {
        if (isMoveToCatchPlayer) {

            dis = Vector3.Distance(transform.position, catchObject.transform.position);

            while (dis >= 3f)
            {
                transform.Translate(Vector3.right * gardMoveSpeed * Time.deltaTime);
                dis = Vector3.Distance(transform.position, catchObject.transform.position);
                yield return null;
            }
                
            isMoveToCatchPlayer=false;
            transform.rotation = Quaternion.Euler(0,180,0);
            StartCoroutine(ReturnTotheStartingPos());

        }
        
    }

    IEnumerator ReturnTotheStartingPos()
    {

        dis = Vector3.Distance(transform.position, startPos.transform.position);

        while (dis >= 3f)
        {
            transform.Translate(Vector3.right * gardMoveSpeed * Time.deltaTime);
            PlayerMoveWithGards();
            dis = Vector3.Distance(transform.position, startPos.transform.position); 
            yield return null;
        }

        transform.rotation = Quaternion.identity;


        if(playerscript.GetPlayerState() == playerState.King && gardType == GardType.Main)
        {
            EventManager.Instance.InvokeSpawnNewEnemyEvent();
        }
        else
        {
            //Temp Solution
             SceneManager.LoadScene("KillTheKing");
            //Plan to not load Scene but again player go for king and start same game play again whthout Load scene
        }

    }

    private void RestartScene()
    {
        SceneManager.LoadScene("KillTheKing");
    }

    private void PlayerMoveWithGards()
    {
        Vector3 playerPos = catchObject.transform.position;
        Vector3 gardPos = transform.position;
        playerPos.x = gardPos.x + 2;
        catchObject.transform.position = playerPos;
    }

    private void MoveToCatchPlayer(object sender, System.EventArgs e)
    {
        isMoveToCatchPlayer = true;
        if(playerscript.GetPlayerState() == playerState.Player) { catchObject = playerObject; }
        else { catchObject = enemygameObject; }
        StartCoroutine(MoveTothePlayer());
    }



}
