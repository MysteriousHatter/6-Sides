using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rubix_cube2 : MonoBehaviour
{
    public int MoveSpeed = 2;
    public float distToGround = 0.5f;
    public float jumpForce = -90;
    public float jumpspeed = 10f;
    public Material Material;
    public Material Material2;
    public Material Material3;
    public Material Material4;
    public Material Material5;
    public Material Material6;
    public Color color;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public string currentcolor;
    KeyCode changecolo;
    KeyCode changecolo2;
    KeyCode changecolo3;
    KeyCode changecolo4;
    KeyCode changecolo5;
    KeyCode changecolo6;
    enum State { Alive, Dead, Goal };
    State Condition = State.Alive;
    [SerializeField] float levelLoadDelay = 2f;

    Rigidbody rb;
    bool canJump;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = true;
        GetComponent<Renderer>();
        Material.color = Color.white;
        Material2.color = Color.white;
        Material3.color = Color.white;
        Material4.color = Color.white;
        Material5.color = Color.white;
        currentcolor = "White";
        Material6.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Condition == State.Alive)
        {
            TransationalInput();
            ColorChange();
        }
    }


    private void TransationalInput()
    {


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * MoveSpeed);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * MoveSpeed);

        }
        else if (canJump)
        {
            if (Input.GetKey(KeyCode.Space))
            {

                Vector3 jumpVelocity = new Vector3(0f, jumpspeed, 0f);
                rb.velocity = rb.velocity + jumpVelocity;
                canJump = false;

            }
        }
    }

    private void ColorChange()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Material.color == Color.white)
            {
                currentcolor = "Red";
                Material.color = color;
            }
            else
            {
                currentcolor = "White";
                Material.color = Color.white;
            }
        }
        /*      else if (Input.GetKeyDown(KeyCode.S))
               {
                   if (Material2.color == Color.white)
                   {
                       currentcolor = "Blue";
                       Material2.color = color2;
                   }
                   else
                   {
                       currentcolor = "White";
                       Material2.color = Color.white;
                   }

               }*/
           /*    else if (Input.GetKeyDown(KeyCode.D))
               {
                   if (Material3.color == Color.white)
                   {
                       currentcolor = "Green";
                       Material3.color = color3;
                   }
                   else
                   {
                       currentcolor = "White";
                       Material3.color = Color.white;
                   }
               }*/
               else if (Input.GetKeyDown(KeyCode.Q))
               {
                   if (Material4.color == Color.white)
                   {
                       currentcolor = "Yellow";
                       Material4.color = color4;
                   }
                   else
                   {
                       currentcolor = "White";
                       Material4.color = Color.white;
                   }
               }
             /*  else if (Input.GetKeyDown(KeyCode.E))
               {
                   if (Material5.color == Color.white)
                   {
                       currentcolor = "Orange";
                       Material5.color = color5;
                   }
                   else
                   {
                       currentcolor = "White";
                       Material5.color = Color.white;
                   }
               }
               else if (Input.GetKeyDown(KeyCode.W))
               {
                   if (Material6.color == Color.white)
                   {
                       currentcolor = "White";
                       Material6.color = color6;
                   }
       
    }*/
    }


    void OnCollisionEnter(Collision collision)
    {
        if (Condition != State.Alive)
        {
            return;
        }
        //Notice you have to create a tag for this method. You can name it the way you want.


        if (collision.gameObject.tag == currentcolor)
        {

            canJump = true;
        }
        else if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("You won");
            LoadFirstLevel();
        }
        else
        {
            Debug.Log("Game Over");
            DeadSequence();
        }

    }

    private void DeadSequence()
    {
        Condition = State.Dead;
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }
    private void SuccessSequence()
    {
        Condition = State.Goal;
    }
}

