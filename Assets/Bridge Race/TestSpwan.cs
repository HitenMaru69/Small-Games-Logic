using UnityEngine;

public class TestSpwan : MonoBehaviour
{
    [SerializeField] GameObject spwanObject;
    [SerializeField] Transform spwanTransform;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpwanObjectAtPosition();
        }
    }

    private void SpwanObjectAtPosition()
    {
        
        GameObject newObject = Instantiate(spwanObject,transform);
        newObject.transform.position = spwanTransform.position;
        newObject.transform.rotation =  Quaternion.Euler(0f,90f,0f);
        ChangeSpwanTransform();
    }

    private void ChangeSpwanTransform()
    {
        Vector3 newPos = spwanTransform.position;
        newPos.y = newPos.y += 0.2f;
        spwanTransform.position = newPos;
    }
}
