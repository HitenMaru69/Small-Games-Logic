using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] float movingSpeed;
    private bool isMove = true;


    private void OnEnable()
    {
        EventManager.Instance.KillKingEvent += StopwallaMovement;
    }

    private void Update()
    {
        if (isMove) 
        {
            MoveWall();
        }
 
    }

    private void OnDisable()
    {
        EventManager.Instance.KillKingEvent -= StopwallaMovement;
    }

    private void MoveWall()
    {
        transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
    }

    private void StopwallaMovement(object sender, System.EventArgs e)
    {
        isMove = false;
    }
}
