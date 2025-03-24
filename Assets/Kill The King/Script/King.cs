using System.Collections;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] CapsuleCollider capsuleCollider;
    [SerializeField] SpawnWall spawnWall;

    private void Start()
    {
        EventManager.Instance.DieKingEvent += OnKingDie;
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
    }







    [ContextMenu("TurnKing")]
    public void TurnKing()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        spawnWall.StopMovingWall();
    }

    [ContextMenu("BackToNormal")]
    public void BackToNormal()
    {
        transform.rotation = Quaternion.identity;
        spawnWall.ResumeMovingWall();
    }
}
