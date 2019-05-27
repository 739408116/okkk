using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject firePrefab;
    public GameObject fireFlashPrefab;

    private GameObject fire;
    private GameObject fireFlash;
    private Collider2D bossCollider;
    private float time = 5f;
    private float Hp = 10f;
    private SpriteRenderer currentSprite;
    private GameObject player;
    private float flashTime = 1f;
    private float moveTime = 0f;

    private Vector3  skillPosition;

    public Sprite angerSprite;
    public Sprite deathSptite;

    private void Start()
    {
        bossCollider = GetComponent<Collider2D>();
        currentSprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    private void Update()
    {

           Move();

    }


    public float TakeDamage(float damage)   
    {
        Hp -= damage;
        if (Hp <= 5f)
        {
            currentSprite.sprite = angerSprite;
            
        }

        if (Hp <= 0f)
        {
            currentSprite.sprite = deathSptite;
            this.transform.GetComponent<Boss>().enabled = false;
            this.transform.GetComponent<CircleCollider2D>().enabled = false;
        }

        return Hp;
    }

    private void Move()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.position += new Vector3(2f, 0f, 0f) * Time.deltaTime;
            currentSprite.flipX = true;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            transform.position -= new Vector3(2f, 0f, 0f) * Time.deltaTime;
            currentSprite.flipX = false;
        }
       
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("time:" + time + " - deltaTime:" + Time.deltaTime + "=" + (time - Time.deltaTime));
        if (collision.gameObject.tag == "Player")
        {
            time -= Time.deltaTime;


            if (time <= 1.02f && time >= 0.98f)
            {
                fireFlash = Instantiate(fireFlashPrefab) as GameObject;
                //fireFlash.transform.parent = this.transform;
                skillPosition = collision.transform.position;
                fireFlash.transform.position = collision.transform.position;
                Destroy(fireFlash, 1f);
            }

            if (time <= 0)
            {

                fire = Instantiate(firePrefab) as GameObject;
                //fire.transform.parent = this.transform;
                fire.transform.position = skillPosition;
                time = 4f;
                Destroy(fire, 2f);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
          {
            time = 4f;
          }
    }




}
