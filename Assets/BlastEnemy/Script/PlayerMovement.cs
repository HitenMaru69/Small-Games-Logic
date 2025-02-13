using Codice.CM.Common;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float amountOfForce;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = transform.position;
            PlayerMove(new Vector2(-2f,2f),-amountOfForce);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = transform.position;
            PlayerMove(new Vector2(2f, 2f),amountOfForce);
        }
    }

    private void FixedUpdate()
    {
        // Chnage Player Move to FixeUpdate rather than Update if Time
    }

    private void PlayerMove(Vector2 dir,float speed)
    {
        rb.linearVelocity = new Vector2(speed, 2);
        rb.AddForce(dir * amountOfForce  ,ForceMode2D.Impulse);
;
    }

}
