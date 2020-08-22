using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDoor : MonoBehaviour
{
    public GameObject Door;
    public GameObject Finish; 
    public MovePlayer player;
    public float speed;
    private bool move = false;
    public AudioSource source;
    public AudioClip DoorSound;
    private void Update()
    {
        if(move == true)
        {
            if (!source.isPlaying)
            {
                source.PlayOneShot(DoorSound);
            }
            
            Door.transform.Translate(0, 0, -speed * Time.deltaTime);
            if(Door.transform.position.y > Finish.transform.position.y)
            {
                move = false;
                source.Stop();
            }

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && player.FinalCheck == 3)
        {
            move = true;

        }
    }
}
