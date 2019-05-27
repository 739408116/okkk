using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManagement : MonoBehaviour
{
    private Collider2D playerCollider;
    private Rigidbody2D playerRig;
    private Animator anim;

    private void Start()
    {
        playerCollider = GetComponent<Collider2D>();
        playerRig = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "MoveFloor")
        {
            transform.parent = collision.transform;
        }


        foreach (ContactPoint2D contact in collision.contacts)
        {
            var direction = transform.InverseTransformPoint(contact.point);
            
            if (collision.gameObject.tag == "Enemy"||collision.gameObject.tag=="Trap")
            {
                
                Debug.DrawLine(contact.point, transform.position, Color.red);
                if (direction.x > 0f)
                {
                    anim.SetBool("hurt", true);
                    playerRig.AddForce(new Vector2(-200f, 0f));

                }
                else if (direction.x < 0f)
                {
                    anim.SetBool("hurt", true);
                    playerRig.AddForce(new Vector2(200f, 0f));
                }

                else if (direction.y > 0f)
                {
                    anim.SetBool("hurt", true);
                    playerRig.AddForce(new Vector2(0, 100f));
                }
            }
            
        }

        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MoveFloor")
        {
            transform.parent = null;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetBool("hurt", false);
        }

        if (collision.gameObject.tag == "Trap")
        {
            anim.SetBool("hurt", false);
        }
    }
}
