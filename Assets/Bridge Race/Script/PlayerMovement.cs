using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;

    private Rigidbody rb;
    private float horizontal;
    private float vertical;
    private Vector3 newPos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        newPos = new Vector3 (horizontal,0,vertical);
        
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }


    private void PlayerMove()
    {
        rb.MovePosition(transform.position + newPos * playerSpeed * Time.fixedDeltaTime);
    }



}
