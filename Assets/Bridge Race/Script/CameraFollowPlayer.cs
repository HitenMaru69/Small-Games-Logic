using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float followSpeed;
    [SerializeField] GameObject player;

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
       Vector3 smoothPosition = Vector3.Lerp(transform.position,player.transform.position +  offset, followSpeed);
        transform.position = smoothPosition;
    }
}
