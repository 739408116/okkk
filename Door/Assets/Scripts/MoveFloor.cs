using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{


    
    private float moveSpeed = 3f;


    private void Update()
    {
        Move();
    }
    private void Move()
    {

        transform.position += Vector3.right * moveSpeed*Time.deltaTime;
        if (transform.position.x >= 10 || transform.position.x <= 1)
        {
            moveSpeed = -moveSpeed;
        }
        

    }
}
