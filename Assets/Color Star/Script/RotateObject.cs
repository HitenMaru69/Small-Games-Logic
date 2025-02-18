using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private void Update()
    {
        transform.Rotate(0, 0, -30 * rotateSpeed * Time.deltaTime);
    }

}
