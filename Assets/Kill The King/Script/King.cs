using System.Collections;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] Animation animations;
    [SerializeField] SpawnWall spawnWall;
    [SerializeField] GamePlay gamePlay;
    
    private void Start()
    {
        EventManager.Instance.DieKingEvent += OnKingDie;
        StartCoroutine(TryToCatchPlayer());
    }

    private void OnDisable()
    {
        EventManager.Instance.DieKingEvent -= OnKingDie;
    }

    private void OnKingDie(object sender, System.EventArgs e)
    {
        Vector3 kingNewPos = transform.position;
        kingNewPos.z = kingNewPos.z + 2;
        transform.position = kingNewPos;
        StopAllCoroutines();
    }

    IEnumerator TryToCatchPlayer()
    {
        
        int timeforTurn = Random.Range(5, 15);
        yield return new WaitForSeconds(timeforTurn);
        animations.Play();
        yield return new WaitForSeconds(1);
        TurnKing();
        yield return new WaitForSeconds(2);
        BackToNormal();
        StartCoroutine(TryToCatchPlayer());

    }


    [ContextMenu("TurnKing")]
    public void TurnKing()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        spawnWall.StopMovingWall();

        if (gamePlay.ChekIftryToKill() == true)
        {
            EventManager.Instance.InvokeCatchKillerEvent();
            StopAllCoroutines();
            Debug.Log("Player diie");
        }
    }

    [ContextMenu("BackToNormal")]
    public void BackToNormal()
    {
        transform.rotation = Quaternion.identity;
        spawnWall.ResumeMovingWall();
    }
}
