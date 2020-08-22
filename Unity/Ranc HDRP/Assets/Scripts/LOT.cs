using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOT : MonoBehaviour
{
    public MovePlayer player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.FinalCheck == 3)
        {
            gameObject.SetActive(false);
        }
        
    }
}
