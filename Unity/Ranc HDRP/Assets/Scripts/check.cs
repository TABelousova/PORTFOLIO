using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    public MovePlayer player;
    public AudioSource source;
    public AudioClip Activetion;
    private bool ivent = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && ivent==true)
        {
            player.FinalCheck += 1;
            source.PlayOneShot(Activetion);
            ivent = false;
        }
    }
}
