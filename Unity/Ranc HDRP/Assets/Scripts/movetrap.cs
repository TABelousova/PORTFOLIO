using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetrap : MonoBehaviour
{
    public GameObject start;
    public GameObject finish;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime, 0, 0);
        if(transform.position.x > start.transform.position.x)
        {
            speed = -speed;
        }
        if(transform.position.x < finish.transform.position.x)
        {
            speed = -speed;
        }

        
    }

}
