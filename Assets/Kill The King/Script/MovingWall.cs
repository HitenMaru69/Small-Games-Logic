using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [SerializeField] float movingSpeed;

    private void Update()
    {
        MoveWall(); 
    }

    private void MoveWall()
    {
        transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
    }

}
