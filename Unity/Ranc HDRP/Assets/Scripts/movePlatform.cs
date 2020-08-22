using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    public GameObject platform;
    public float speed;
    private bool move = false;
    public AudioSource source;
    public AudioClip Platform;
    // Update is called once per frame
    void Update()
    {
        if(move == true)
        {
            platform.transform.Translate(0, -speed*Time.deltaTime, 0);
            if (!source.isPlaying)
            {
             source.PlayOneShot(Platform);
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            move = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            move = false;
        }
    }
}
