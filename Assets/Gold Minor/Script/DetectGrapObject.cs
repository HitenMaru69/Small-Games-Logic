using UnityEngine;

public class DetectGrapObject : MonoBehaviour
{
    [SerializeField] Hook hook;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrapObject")
        {
            collision.gameObject.transform.SetParent(transform);
            hook.isgoingForGrap = false;
            hook.isGoingBack = true;
            
        }
    }

}
