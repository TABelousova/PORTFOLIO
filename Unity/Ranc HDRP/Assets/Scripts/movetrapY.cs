using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetrapY : MonoBehaviour
{
    public GameObject start;
    public GameObject finish;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.fixedDeltaTime);
        if (transform.position.z < start.transform.position.z)
        {
            speed = -speed;
        }
        if (transform.position.z > finish.transform.position.z)
        {
            speed = -speed;
        }

    }
}
