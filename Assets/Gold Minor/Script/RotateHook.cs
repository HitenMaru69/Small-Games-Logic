using Unity.VisualScripting;
using UnityEngine;

public class RotateHook : MonoBehaviour
{
    public bool isRotate;

    [SerializeField] GameObject rotateObject;
    [SerializeField] float rotateSpeed;
    [SerializeField] bool isReverceRotate;

    private void Start()
    {
        isRotate = true;


    }

    private void Update()
    {

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

 
}
