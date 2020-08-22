using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public MovePlayer player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.CHECKPOINT.transform.position = transform.position;
        }
    }
}
