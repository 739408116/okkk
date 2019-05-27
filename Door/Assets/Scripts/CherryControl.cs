using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryControl : MonoBehaviour
{
    private Collider2D cherryCollider;
    private GameObject flash;
    private PlayerMove playerMove;
    private float damage = 1f;
    private Boss boss;

    public GameObject flashPrefab;

    private void Update()
    {
        Attack();
    }

    private void Start()
    {
        cherryCollider = GetComponent<Collider2D>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }

    private void Attack()
    {
        if (playerMove.attacking)
        {
            transform.localPosition += new Vector3(0, 5f * Time.deltaTime, 0);
            
        }

        if (transform.position.y >= 15)
        {
            Destroy(this.gameObject);
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            this.transform.parent = collision.transform;
        }

        if (collision.gameObject.tag == "Boss")
        {
            flash = Instantiate(flashPrefab) as GameObject;
            flash.transform.position = transform.position;
            Destroy(this.gameObject);
            Destroy(flash, 0.5f);
            boss.TakeDamage(damage);
        }
    }

   
}
