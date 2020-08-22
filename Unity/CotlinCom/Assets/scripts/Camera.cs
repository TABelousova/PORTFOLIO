using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public PlayerMove Player;
    public Transform MainCamera;
    private float shakeX = 0.05f, shakeY = 0.05f;
    private bool CameraShake = false;
    private Vector3 OriginPlaceCamera;
    void Start()
    {
        OriginPlaceCamera = MainCamera.localPosition;
    }
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.5f);
        Player.GameOver = false;
        MainCamera.transform.localPosition = OriginPlaceCamera;
        
    }


    void Update()
    {
        if (Player.GameOver == true)
        {
           Vector3 Shake = new Vector3(Random.Range(-shakeX, shakeX), Random.Range(-shakeY, shakeY), 0);
           MainCamera.transform.localPosition += Shake;
           StartCoroutine("Pause");
           
        }
    }
}
