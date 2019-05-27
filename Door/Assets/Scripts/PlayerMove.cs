using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Rigidbody2D playerRig;
    private Animator anim;
    private State state=State.idle;
    private SpriteRenderer playerSprite;
    private Transform groundCheck;
    private bool isAttack;

    public bool attacking;
    public bool grounded;

    enum State
    {
        idle,
        run,
        jump,
    }

    enum Direction 
    {
        None=1,
        up,
        down,
        left,
        right,
    }
    private void Start()
    {
        grounded = true;
        attacking = false;
        playerRig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        groundCheck = this.transform.Find("groundCheck");
    }
    private void FixedUpdate()
    {
       
        Move();
        Jump();
        Attack();
    }

    private void Move()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {
            Run(Direction.left, Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Run(Direction.right, Vector2.right);

        }

        if (Input.GetKey(KeyCode.S))
        {
                this.transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        if (state == State.run)
        {
            if (Mathf.Approximately(x, 0f) && Mathf.Approximately(y, 0f))
            { SetState(State.idle); }
        }
    }

    private void SetState(State newState)
    {
        state = newState;
        anim.SetBool("run", state==State.run);
        anim.SetBool("jump", state == State.jump);
    }

    private void Run(Direction dir,Vector2 position)
    {
        SetState(State.run);
        playerSprite.flipX = (dir == Direction.left);
        transform.Translate(position * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        grounded = Physics2D.Linecast(this.transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Floor"));

            if (Input.GetKey(KeyCode.W)&&grounded)
            {
                playerRig.AddForce(new Vector2(0, 80f));
                SetState(State.jump);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                SetState(State.idle);
            }
        
    }

    private void Attack()
    {
        isAttack = transform.Find("cherry(Clone)");
        if (isAttack && Input.GetKeyDown(KeyCode.F))
        {
            attacking = true;

        }
        else if (!isAttack)
        {
            attacking = false;
        }
        
        
    }
}
