using System.Collections;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject hookHolder;
    [SerializeField] GameObject hook;
    [SerializeField] RotateHook rotateHook;
    [SerializeField] float hookSpeed;

    public bool isgoingForGrap;
    public bool isGoingBack;



    private void Start()
    {
        isgoingForGrap = false;
        isGoingBack = false;
    }

    private void Update()
    {
        MakeRope();

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isgoingForGrap = true;
            rotateHook.isRotate = false;
        }

        if (isgoingForGrap) {

            GoingForGrap();
        }

        if (isGoingBack) {
            CheckForOriganlPosition();
        }
    }


    private void MakeRope()
    {
        lineRenderer.SetPosition(0, hookHolder.transform.position);
        lineRenderer.SetPosition(1, hook.transform.position);
    }

    private void GoingForGrap()
    {
        if(hook.transform.localPosition.y >= -7f)
        {
            hook.transform.Translate(Vector2.down * hookSpeed * Time.deltaTime);
        }
        else
        {
            isgoingForGrap = false;
            isGoingBack = true;
         
        }

    }

    private void CheckForOriganlPosition()
    {
        if (hook.transform.localPosition.y <= -0.8f)
        {
            hook.transform.Translate(Vector2.up * hookSpeed * Time.deltaTime);

        }
        else
        {
            if (hook.transform.childCount > 0)
            {
                Destroy(hook.transform.GetChild(0).gameObject);
            }

            isGoingBack = false;
            rotateHook.isRotate = true;

        }
    }



}
