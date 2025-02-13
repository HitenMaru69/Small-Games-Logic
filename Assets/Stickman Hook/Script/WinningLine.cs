using UnityEngine;

public class WinningLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Win Logic 
            Debug.Log("You win");
        }
    }
}
