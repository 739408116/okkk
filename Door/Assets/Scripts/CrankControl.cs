using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrankControl : MonoBehaviour
{
    private Collider2D crankCollider;
    private Animation anim;
    private GameObject platForm;
    
   

    private void Awake()
    {
        platForm = GameObject.Find("Platform");
    }
    private void Start()
    {
        crankCollider = GetComponent<Collider2D>();
        anim = this.GetComponent<Animation>();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            if (Input.GetKey(KeyCode.Space))
            {
                anim.Play("crank");
                platForm.transform.GetComponent<SpriteRenderer>().enabled = false;
                platForm.transform.GetComponent<BoxCollider2D>().enabled=false;
            }
        }
    }
}
