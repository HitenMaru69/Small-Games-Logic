using UnityEngine;

public class Grapple : MonoBehaviour
{
    private string grappleTag = "Grapple";
    [SerializeField] DistanceJoint2D distanceJoint2D;

    Vector2 grapplePoint;

    private void Start()
    {
        distanceJoint2D.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(mousePos, Vector2.zero,Mathf.Infinity);

            if (raycastHit2D.collider != null)
            {
                if(raycastHit2D.collider.gameObject.tag == grappleTag)
                {
                    grapplePoint = raycastHit2D.point;
                    distanceJoint2D.connectedAnchor = grapplePoint;
                    distanceJoint2D.distance = 2f;
                    distanceJoint2D.enabled = true;


                }

            }
            else
            {
                Debug.Log("Else called");
            }
        }
    }

}
