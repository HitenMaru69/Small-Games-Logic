using System.Collections;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] CapsuleCollider capsuleCollider;

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
}
