using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLevel : MonoBehaviour
{
    public int level_To;

    private void NextLevel(int _level)
    {
        SceneManager.LoadScene(_level);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            NextLevel(level_To);
        }
    }
}
