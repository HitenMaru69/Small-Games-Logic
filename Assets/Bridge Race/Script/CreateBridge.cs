using UnityEngine;

public class CreateBridge : MonoBehaviour
{
    [SerializeField] GameObject brick;
    [SerializeField] Transform spwanTransform;

    private string bridgeTag = "Bridge";
    private GameObject lastObject;
    private bool isOnBridge = true;
    private bool isTrigger = true;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == bridgeTag && isOnBridge && isTrigger)
        {
            BridgeCreate();
            isTrigger = false;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Exit")
        {
            isOnBridge = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == lastObject && collision.gameObject.tag == bridgeTag)
        {
            if (isOnBridge) {
                BridgeCreate();
            }
            
        }
    }

    private void BridgeCreate()
    {
        if (BrickManager.instance.CheckTotalBrick() > 0)
        {
            GameObject newSpwanObject = Instantiate(brick, spwanTransform.position, Quaternion.identity);
            newSpwanObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            lastObject = newSpwanObject;
            BrickManager.instance.RemoveBrick();
            ChnageSpwanTransform();

        }
        
    }

    private void ChnageSpwanTransform()
    {
        spwanTransform.position += spwanTransform.forward * 0.25f;
    }

   
}
