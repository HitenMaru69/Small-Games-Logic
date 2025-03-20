using UnityEngine;

public class Grapple : MonoBehaviour
{
 
    [SerializeField] DistanceJoint2D distanceJoint2D;
    [SerializeField] LineRenderer lineRenderer;
    private string grappleTag = "Grapple";
    private Vector2 grapplePoint;

    private void Start()
    {
        distanceJoint2D.enabled = false;
        lineRenderer.enabled = false;
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
                    SetGrapple(grapplePoint);
                    SetLine(grapplePoint);
                    
                }

            }

        }

        if (lineRenderer.enabled == true) { 
        
            lineRenderer.SetPosition(1,transform.position);
        }

        if (Input.GetMouseButtonUp(0)) { 
        
            distanceJoint2D.enabled = false ;
            lineRenderer.enabled = false;
        }
    }

    private void SetGrapple(Vector3 point)
    {
        distanceJoint2D.connectedAnchor = point;
       // distanceJoint2D.distance = 2f;
        distanceJoint2D.autoConfigureDistance = true;  //if we use this than we have to manully assign distance to the object and point
        distanceJoint2D.enabled = true;

    }

    private void SetLine(Vector3 point)
    {
        lineRenderer.SetPosition(0, point);
        lineRenderer.SetPosition(1,transform.position);
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.enabled = true;
    }

}
