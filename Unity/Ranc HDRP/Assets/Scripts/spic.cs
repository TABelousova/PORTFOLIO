using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spic : MonoBehaviour
{
    public MovePlayer player;
    public int Damage;
    public AudioSource source;
    public AudioClip DamageSound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.Health -= Damage;
            source.PlayOneShot(DamageSound);
        }
    }
}
