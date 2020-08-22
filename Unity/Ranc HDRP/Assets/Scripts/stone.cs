using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone : MonoBehaviour
{
    public MovePlayer player;
    public int Damage;
    public AudioSource source;
    public AudioClip StoneSTOP;
    public AudioClip DamageSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Health -= Damage;
            source.PlayOneShot(DamageSound);      
        }
        if(other.tag == "STOP")
        {
            source.Stop();
            if(!source.isPlaying)
            { 
            source.PlayOneShot(StoneSTOP); 
            }
            
        }
    }
}
