using UnityEngine;

public class CollectBrick : MonoBehaviour
{
    [SerializeField] Transform spwanTransform;

    private string brickTag = "Brick";


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == brickTag)
        {
            BrickCollect(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void BrickCollect(GameObject spwanObject)
    {
        GameObject newObject = Instantiate(spwanObject, transform);
        newObject.transform.position = spwanTransform.position;
        newObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        BrickManager.instance.UpdateTotalBrickCount(newObject);
        ChangeSpwanTransform();
    }

    private void ChangeSpwanTransform()
    {
        Vector3 newPos = spwanTransform.position;
        newPos.y = newPos.y += 0.2f;
        spwanTransform.position = newPos;
    }

}
