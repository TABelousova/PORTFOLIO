using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class spiderControler : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    ///main variables
    /// </summary>
    public Rigidbody spider;
    private Animator Animator;
    public float speed; //speed spider
    public float jumpforse; //jump forse if spider
    public float speedRot;
    private Vector3 moveVector; //vector for movment 
    private float flymove = 0;
    private float deathflay = 3;
    private bool life = true;
    

    void Start()
    {
        Animator = GetComponent<Animator>();
        spider = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life == true)
        {
            _move();
        }
        Gravity();
        Animation();

     
    }
    private void _move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//получение значение движения по горизонтали 
        float moveVertical = Input.GetAxis("Vertical"); //по вертикали 
        moveVector = new Vector3(-moveHorizontal, 0, -moveVertical); 
        transform.Translate(moveVector * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -speedRot * speedRot, 0);
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, speedRot * speedRot, 0);
        }
    }
    private void Gravity()
    {
        bool Ground = Physics.Raycast(transform.position, -transform.up, 1);
        if (Input.GetKeyDown(KeyCode.Space) && Ground == true)
        {
            spider.AddForce(Vector3.up * jumpforse*1000 * Time.deltaTime);
        }
        if(Ground==false)
        {
            flymove += Time.deltaTime;
            Debug.Log(flymove);
            if(flymove >= deathflay)
            {
                life = false;
            }
        }
        else
        {
            flymove = 0;
            Debug.Log(flymove);
        }
    }
     IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.7f);
        Animator.enabled = false;
    }
    private void Animation()
    {
        bool Ground = Physics.Raycast(transform.position, -transform.up, 1);
         if (flymove >= 1 && Ground == false)
         {
            Animator.SetBool("fall", true);
         }
        else
        {
            Animator.SetBool("fall", false);
        }

        if (life == true)
        {
            if (Input.GetKey(KeyCode.W) && Ground == true)
            {
                Animator.SetBool("MoveForward", true);
            }
            else if (Input.GetKey(KeyCode.S) && Ground == true)
            {
                Animator.SetBool("MoveBack", true);
            }
            else if (Input.GetKey(KeyCode.A) && Ground == true)
            {
                Animator.SetBool("moveH", true);
            }
            else if (Input.GetKey(KeyCode.D) && Ground == true)
            {
                Animator.SetBool("moveH", true);
            }
            else if (Input.GetKey(KeyCode.Q) && Ground == true)
            {
                Animator.SetBool("rotLeft", true);
            }
            else if (Input.GetKey(KeyCode.E) && Ground == true)
            {
                Animator.SetBool("rotRigth", true);
            }
            else if (Input.GetKey(KeyCode.Mouse0) && Ground == true)
            {
                Animator.SetBool("attac", true);
            }
            else if (Input.GetKey(KeyCode.Mouse1) && Ground == true)
            {
                Animator.SetBool("attac2", true);
            }
            else if (Input.GetKey(KeyCode.Space) && Ground == true)
            {
                Animator.SetBool("jump", true);
            }
            else if (Input.GetKey(KeyCode.G) && Ground == true)
            {
                Animator.SetBool("longattack", true);
            }
            else if(flymove >= 1 && Ground == false)
            {
                Animator.SetBool("fall", true);
            }
            else
            {
                Animator.SetBool("MoveForward", false);
                Animator.SetBool("MoveBack", false);
                Animator.SetBool("rotLeft", false);
                Animator.SetBool("rotRigth", false);
                Animator.SetBool("attac", false);
                Animator.SetBool("attac2", false);
                Animator.SetBool("jump", false);
                Animator.SetBool("moveH", false);
                Animator.SetBool("longattack", false);
            }
        }
        else
        {
            if(Ground==true)
            {
                Animator.SetBool("death", true);
                StartCoroutine("Stop");
                
            }
            Animator.SetBool("MoveForward", false);
            Animator.SetBool("MoveBack", false);
            Animator.SetBool("rotLeft", false);
            Animator.SetBool("rotRigth", false);
            Animator.SetBool("attac", false);
            Animator.SetBool("attac2", false);
            Animator.SetBool("jump", false);
            Animator.SetBool("moveH", false);
            Animator.SetBool("longattack", false);
            
        }
    }
}
    
