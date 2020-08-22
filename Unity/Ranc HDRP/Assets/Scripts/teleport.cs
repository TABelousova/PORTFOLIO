using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public MovePlayer player;
    public GameObject TeleportPlase;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.transform.position = TeleportPlase.transform.position;
            player.transform.rotation = TeleportPlase.transform.rotation;
        }
    }
}
