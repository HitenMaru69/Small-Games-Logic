using Unity.VisualScripting;
using UnityEngine;

public class RotateHook : MonoBehaviour
{
    public bool isRotate;

    [SerializeField] GameObject rotateObject;
    [SerializeField] float rotateSpeed;
    [SerializeField] bool isReverceRotate;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject ground;
    

    private Vector2 satrthookPosition = new Vector2(0f,5f);

    private void Start()
    {
        isRotate = true;


    }

    private void Update()
    {

        MakeRope();

        if (Input.GetKeyDown(KeyCode.Space)) { 
        
            isRotate = false;

        }

        lineRenderer.SetPosition(0, ground.transform.position);
        lineRenderer.SetPosition(1,rotateObject.transform.position);

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotateObject.transform.Translate(Vector2.down * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(rotateObject.transform.position.y <= 5)
            {
                rotateObject.transform.Translate(satrthookPosition * rotateSpeed * Time.deltaTime);
            }

        }

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    isRotate = true;
        //}

        StartRotate();
    }


    private void StartRotate()
    {
        if (isRotate)
        {

            float currentRotation = rotateObject.transform.eulerAngles.z;

            if (isReverceRotate)
            {
                rotateObject.transform.Rotate(new Vector3(0, 0, -40) * rotateSpeed * Time.deltaTime);
            }
            else
            {
                rotateObject.transform.Rotate(new Vector3(0, 0, 40) * rotateSpeed * Time.deltaTime);
            }

            if (currentRotation > 180)
            {
                currentRotation -= 360;
            }


            if (currentRotation >= 40f)
            {
                isReverceRotate = true;
            }

            if (currentRotation <= -40f)
            {
                isReverceRotate = false;
            }
        }

    }

    private void MakeRope()
    {
        lineRenderer.SetPosition(0,ground.transform.position);
        lineRenderer.SetPosition(1,rotateObject.transform.position);

        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
    }
}
