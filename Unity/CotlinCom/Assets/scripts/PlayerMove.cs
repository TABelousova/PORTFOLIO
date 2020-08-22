using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    
    public Rigidbody Player;
    public Text Score_Text, GameOver_Text;
    public GameObject[] PlaceSpawn, PlaseTeleport;
    public GameObject Panel, Effect;
    public bool GameOver = false;
    private bool Status = false, Pause = false;
    private int Score = 0, SpawnScore = 4;
    private GameObject Coin, Bot, Level;
    private Vector3 StartPosition;
    private Animator Animator;
    private float JumpForce = 1000;
    private AudioSource AudioSource;
    private AudioClip[] AudioClips;
    void Start()
    {
        //shotdown pamel
        Panel.SetActive(false);
        //conection Component
        Player = GetComponent<Rigidbody>();
        Animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
        //Save start positipon player
        StartPosition = Player.transform.position;
        //Spawn Object(Coin)
        Coin  = Instantiate(Resources.Load<GameObject>("prefabs/Object/Sphere"));
        Level = Instantiate(Resources.Load<GameObject>("prefabs/Object/Level"));
        //Shoice place spawn Coin
        GameObject NewPlaceSpawn = PlaceSpawn[Random.Range(0, PlaceSpawn.Length)];
        //transform Coin
        Coin.transform.position = NewPlaceSpawn.transform.position;
        //Game Status
        AudioClips = Resources.LoadAll<AudioClip>("Sound");
    }
    /// <summary>
    /// Audio
    /// </summary>
    private void AudioPlay()
    {
        if (!AudioSource.isPlaying)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                AudioSource.PlayOneShot(AudioClips[1]);
            }
            else
            {
                AudioSource.PlayOneShot(AudioClips[0]);
            }
        }
    }
    /// <summary>
    /// Movment metod
    /// </summary>
    private void MovePlayer()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Player.AddForce(Vector3.up*JumpForce*Time.deltaTime);
            Animator.SetBool("Up", true);
        }
        else
        {
            Animator.SetBool("Up", false);  
        }
        if(Input.GetKey(KeyCode.D))
        {
            Player.AddForce(-1*JumpForce*Time.deltaTime, 1*JumpForce*Time.deltaTime, 0);
            Animator.SetBool("Rigth", true);
        }
        else
        {
            Animator.SetBool("Rigth", false);
            
        }
        if(Input.GetKey(KeyCode.A))
        {
            Player.AddForce(1*JumpForce * Time.deltaTime, 1*JumpForce * Time.deltaTime, 0);
            Animator.SetBool("Left", true);
        }
        else
        {
            Animator.SetBool("Left", false);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pause == false)
            {
                Pause = true;
                Time.timeScale = 0;
                Panel.SetActive(Pause);
            }
            else
            {
                Pause = false;
                Time.timeScale = 1;
                Panel.SetActive(Pause);
            }
        }
    }
    IEnumerator TimeSlep()
    {
        yield return new WaitForSeconds(1f);
        Status = false;
    }
    /// <summary>
    /// Metod on spawn
    /// </summary>
    private void Spawn()
    {
        //Create new object (Coin)
        Coin = Instantiate(Resources.Load<GameObject>("prefabs/Object/Sphere"));
        //Choice new place at spawn object
        GameObject NewPlaceSpawn = PlaceSpawn[Random.Range(0, PlaceSpawn.Length)];
        //transform object
        Coin.transform.position = NewPlaceSpawn.transform.position;
        StartCoroutine(TimeSlep());
    }
    /// <summary>
    /// Ivent triger
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
         if(other.tag == "Tagert")
         {
            //Destroy Coin
            AudioSource.PlayOneShot(AudioClips[3]);
            
            Destroy(other.gameObject);
            Score += 1;
            //Rise dificult
            Status = true;
            Player.mass += 0.02f;
            if (Score == SpawnScore)
            //Spawn Bot
            {
                Bot = Instantiate(Resources.Load<GameObject>("prefabs/Object/bot"));
                Bot.AddComponent<bot>();
                SpawnScore += 3;
            }
            Spawn();

         }
         if(other.tag == "Trap")
         {
            GameOver = true;
            Player.transform.position = StartPosition;
            Panel.SetActive(true);
            Player.constraints = RigidbodyConstraints.FreezeAll;
            AudioSource.PlayOneShot(AudioClips[4]);
         }
         if(other.tag == "T1")
         {
            Player.transform.position = PlaseTeleport[2].transform.position;
            AudioSource.PlayOneShot(AudioClips[5]);
         }
         else if(other.tag == "T2")
         {
            Player.transform.position = PlaseTeleport[3].transform.position;
            AudioSource.PlayOneShot(AudioClips[5]);
         }
         else if (other.tag == "T3")
         {
            Player.transform.position = PlaseTeleport[0].transform.position;
            AudioSource.PlayOneShot(AudioClips[5]);
         }
         else if (other.tag == "T4")
         {
            Player.transform.position = PlaseTeleport[1].transform.position;
            AudioSource.PlayOneShot(AudioClips[5]);
         }

    }
    void Update()
    {
        Score_Text.text = "Score: " + Score.ToString();
        GameOver_Text.text = "Game Over Score: " + Score.ToString(); 
        MovePlayer();
        AudioPlay();
        Effect.SetActive(Status);
    }
}
