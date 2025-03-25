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


    private void Update()
    {
        dis = Vector3.Distance(transform.position, player.transform.position);
        
        if(dis >= 3f)
        {
            transform.Translate(Vector3.right * gardMoveSpeed * Time.deltaTime);
        }
        
    }

    private void OnDisable()
    {
        EventManager.Instance.CatchKillerEvent -= MoveToCatchPlayer;
    }


    IEnumerator MoveTothePlayer()
    {
        yield return null;
    }

    private void MoveToCatchPlayer(object sender, System.EventArgs e)
    {
        isMoveToCatchPlayer = true;
    }




}
