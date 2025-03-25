using System.Collections;
using UnityEngine;

public class Gards : MonoBehaviour
{

    [SerializeField] Transform startPos;
    [SerializeField] GameObject player;
    [SerializeField] float gardMoveSpeed;

    private bool isMoveToCatchPlayer;

    [SerializeField] float dis;

    private void Start()
    {
        isMoveToCatchPlayer = false;
        EventManager.Instance.CatchKillerEvent += MoveToCatchPlayer;
    }

    private void OnDisable()
    {
        EventManager.Instance.CatchKillerEvent -= MoveToCatchPlayer;
    }


    IEnumerator MoveTothePlayer()
    {
        if (isMoveToCatchPlayer) {

            dis = Vector3.Distance(transform.position, player.transform.position);

            while (dis >= 3f)
            {
                transform.Translate(Vector3.right * gardMoveSpeed * Time.deltaTime);
                dis = Vector3.Distance(transform.position, player.transform.position);
                yield return null;
            }
                
            isMoveToCatchPlayer=false;
        }
        
    }

    private void MoveToCatchPlayer(object sender, System.EventArgs e)
    {
        isMoveToCatchPlayer = true;
        StartCoroutine(MoveTothePlayer());
    }




}
