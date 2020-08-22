using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{
    public Rigidbody Player;
    public float speed;
    public float speedCam;
    public float jump_forse;
    public int Health;
    private int Life = 3;
    public Slider slider_Health;
    public Text Text_Health;
    private bool squatting = true;
    public GameObject START;
    public GameObject CHECKPOINT;
    public bool Check = false;
    public int FinalCheck = 0;
    private AudioSource sourse;
    public AudioClip[] Step;
    private float DistanseGround = 0.55f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Player = GetComponent<Rigidbody>();
        sourse = GetComponent<AudioSource>();
        Player.transform.position = START.transform.position;
        CHECKPOINT.transform.position = START.transform.position;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        bool IsGround = Physics.Raycast(transform.position, -transform.up, out hit, DistanseGround);
        slider_Health.value = Health;
        Text_Health.text = Health.ToString() + " HP" + " and " + Life.ToString() + " Life";
        if (Health <= 0)
        {
            Player.transform.position = CHECKPOINT.transform.position;
            Life -= 1;
            Health = 100;
            if (Life == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (Health > 0)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * speedCam, 0);//функция поворота объекта по оси Х
            float moveHorizontal = Input.GetAxis("Horizontal");//получение значение движения по горизонтали 
            float moveVertical = Input.GetAxis("Vertical"); //по вертикали 
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //ветор для движения 
            //движение вперед + ускорение 
            if (Input.GetKey(KeyCode.W))//движение вперед + ускорение 
            {
                //звуки по поверхности
                if (!sourse.isPlaying && IsGround == true)//если звук не играет и на земле 
                {
                    if (hit.collider.tag == "Rock")
                    {
                        sourse.PlayOneShot(Step[0]);
                    }
                    else if (hit.collider.tag == "Metal")
                    {
                        sourse.PlayOneShot(Step[1]);
                    }
                    else if (hit.collider.tag == "Wood")
                    {
                        sourse.PlayOneShot(Step[2]);
                    }
                }
                transform.Translate(movement* speed * Time.fixedDeltaTime);
                if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
                {
                    speed = speed * (3 / 2);
                    transform.Translate(movement * speed * Time.fixedDeltaTime);
                } 
            }
            //движение назад
            if (Input.GetKey(KeyCode.S))//движение назад
            {
                //звуки по поверхности
                if (!sourse.isPlaying && IsGround == true)
                {
                    if (hit.collider.tag == "Rock")
                    {
                        sourse.PlayOneShot(Step[0]);
                    }
                    else if (hit.collider.tag == "Metal")
                    {
                        sourse.PlayOneShot(Step[1]);
                    }
                    else if (hit.collider.tag == "Wood")
                    {
                        sourse.PlayOneShot(Step[2]);
                    }
                }
                    transform.Translate(movement * speed * Time.fixedDeltaTime);
                //Player.MovePosition(Player.position + Vector3.back * speed / 2 * Time.fixedDeltaTime);
            }
            //Движение влево 
            if (Input.GetKey(KeyCode.A))//движение влево
            {
                //звуки по поверхности
                if (!sourse.isPlaying && IsGround == true)
                {
                    if (hit.collider.tag == "Rock")
                    {
                        sourse.PlayOneShot(Step[0]);
                    }
                    else if (hit.collider.tag == "Metal")
                    {
                        sourse.PlayOneShot(Step[1]);
                    }
                    else if (hit.collider.tag == "Wood")
                    {
                        sourse.PlayOneShot(Step[2]);
                    }
                }
                transform.Translate(movement * (speed/2) * Time.fixedDeltaTime);
                //Player.MovePosition(Player.position + Vector3.left * speed * Time.fixedDeltaTime);
            }
            //Движение вправо
            if (Input.GetKey(KeyCode.D))//движение вправо 
            {
                //звуки по поверхности
                if (!sourse.isPlaying && IsGround == true)
                {
                    if (hit.collider.tag == "Rock")
                    {
                        sourse.PlayOneShot(Step[0]);
                    }
                    else if (hit.collider.tag == "Metal")
                    {
                        sourse.PlayOneShot(Step[1]);
                    }
                    else if (hit.collider.tag == "Wood")
                    {
                        sourse.PlayOneShot(Step[2]);
                    }
                }
                transform.Translate(movement * (speed/2) * Time.fixedDeltaTime);
                //Player.MovePosition(Player.position + Vector3.right * speed * Time.fixedDeltaTime);
            }
            //приседание
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (squatting == true)
                {
                    Player.transform.localScale = Player.transform.localScale / 2;
                    squatting = false;
                }
                else
                {
                    Player.transform.localScale = Player.transform.localScale * 2;
                    squatting = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Space ) && Health > 0 && Life > 0)//задаем прыжок
            {
                if (IsGround == true)
                {
                    sourse.PlayOneShot(Step[3]);
                    Player.AddForce(Vector3.up * jump_forse * Time.fixedDeltaTime);
                } 
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    //private void Update()
    //{
    //      // прыжок (пришлось создать отдельный Update потому что в Fixed срабатывает через раз  
    //       if (Input.GetKeyDown(KeyCode.Space) && Health > 0 && Life > 0)//задаем прыжок
    //       {
    //            Player.AddForce(Vector3.up * jump_forse * Time.deltaTime);
            
    //       }
    //       if(Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
    //       {
    //            Player.AddForce(Vector3.up * jump_forse *2* Time.deltaTime);
    //       }
    //       //if (Input.GetKeyDown(KeyCode.F) && Health > 0 && Life > 0)
    //       //     {
    //       //    if (flashlight_bool == false)
    //       //     {
    //       //         flashlight.SetActive(flashlight_bool);
    //       //         flashlight_bool = true;
    //       //     }
    //       //     else if (flashlight_bool == true)
    //       //     {
    //       //         flashlight.SetActive(flashlight_bool);
    //       //         flashlight_bool = false;
    //       //     }
    //    }
    private void OnCollisionEnter(Collision collision)
    {
        slider_Health.value = Health;
        if (collision.gameObject.tag == "elevator")
        {
            this.transform.parent = collision.transform;
        }
        if(collision.relativeVelocity.magnitude>=2)
        {
            sourse.PlayOneShot(Step[4]);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        this.transform.parent = null;
    }

}





