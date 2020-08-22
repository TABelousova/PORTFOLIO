using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public MovePlayer player;
    public GameObject HealthBar;
    public AudioSource source;
    public AudioClip HelthSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.Health = 100;
            source.PlayOneShot(HelthSound);
            HealthBar.SetActive(false);
        }
    }
}
