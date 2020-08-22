using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpher : MonoBehaviour
{
    public MovePlayer player;
    public GameObject spher;
    public GameObject start; 
    private bool move = false;
    public AudioSource Stone;
    public AudioClip StoneSound; 
    
    private void Update()
    {
        spher.SetActive(move);
        if(player.Health <= 0)
        {
            spher.transform.position = start.transform.position;
            move = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            move = true;
            Stone.PlayOneShot(StoneSound);
        }
    }

}

