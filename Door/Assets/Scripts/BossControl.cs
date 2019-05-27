using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    private float moveSpeed = 0.7f;
    private float gravity = -3.0f;
    private bool grounded;
    private Transform groundCheck;

    private void Start()
    {
        groundCheck = this.transform.Find("GroundCheck");
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Floor"));

        if (grounded)
        {
            this.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= 24f || transform.position.x >= 30)
            {
                moveSpeed = -moveSpeed;
            }
        }
        
        else if (!grounded)
        {
            transform.position -= Vector3.down * gravity * Time.deltaTime;
            Destroy(this.gameObject, 3f);
        }
    }
}
