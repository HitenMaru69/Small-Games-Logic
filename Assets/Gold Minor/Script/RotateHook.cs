using UnityEngine;

public class RotateHook : MonoBehaviour
{
    [SerializeField] GameObject rotateObject;
    [SerializeField] float rotateSpeed;
    [SerializeField] bool isReverceRotate;

    private void Start()
    {
      
    }

    private void Update()
    {
        StartRotate();
    }


    private void StartRotate()
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

        if(currentRotation > 180)
        {
            currentRotation -= 360;
        }


        if (currentRotation >= 40f )
        {
            isReverceRotate = true;
        }

        if(currentRotation <= -40f)
        {
            isReverceRotate = false;
        }

    }
}
