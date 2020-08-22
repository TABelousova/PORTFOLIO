using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    public MovePlayer player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.Health = 0;
        }
    }

}
