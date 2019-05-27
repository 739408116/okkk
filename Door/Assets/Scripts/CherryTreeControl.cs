using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryTreeControl : MonoBehaviour
{
    public GameObject cherryPrefab;

    private bool isProduce;
    private GameObject sakura;
    private float time = 5f;


    private void Start()
    {
        isProduce = true;
    }
    private void Update()
    {
        isProduce = !(GameObject.FindGameObjectWithTag("Sakura"));

        if (isProduce)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                sakura = Instantiate(cherryPrefab) as GameObject;
                sakura.transform.position = new Vector3(transform.position.x, transform.position.y-2, 0);
                time = 5f;
            }
        }
        
    }
}
