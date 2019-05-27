using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float moveSpeed = 1f;
    private SpriteRenderer enemySprite;
    private State state;
    private Animator anim;
    

    enum State
    {
        idle,
        walk,
    }

    enum Direction
    {
        None=1,
        left,
        right,
    }

    private void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        
            
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        setState(State.walk);
        

        
        if (transform.position.x >= 9)
        {
            WalkRotate(Direction.right);
        }
        else if (transform.position.x <= 2)
        {
            WalkRotate(Direction.left);
        }
        
    }

    private void setState(State newState)
    {
        state = newState;
        anim.SetBool("walk", state == State.walk);
    }

    private void WalkRotate(Direction dir)
    {
        
        setState(State.walk);
        moveSpeed = -moveSpeed;
        enemySprite.flipX = (dir == Direction.left);
      

    }
}
